using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MercenaryCollected : MonoSingleton<MercenaryCollected>
{
    [SerializeField] private GameObject storePanel;
    [SerializeField] private GameObject inventoryPanel;

    [SerializeField] private Image infoImage;
    [SerializeField] private TextMeshProUGUI mercenaryName;
    [SerializeField] private TextMeshProUGUI mercenaryExplain;

    [SerializeField] private MercenaryContent collected;

    [SerializeField] private TMP_Text cashText;

    private SaveSystem save;
    private GameData data;

    public int MercenaryCount = 0;

    //public int[] numbers = { 0, 0, 0, 0, 0, 0 };
    public List<int> numbers = new List<int>();
    int totalCount = 0;
    public List<GameObject> StoreContents = new List<GameObject>();
    public List<GameObject> InventoryContents = new List<GameObject>();

    [SerializeField] private GameObject mercenaryContent;

    public ScrollRect StoreScrollRect; // ScrollRect ����
    public ScrollRect InventoryScrollRect; // ScrollRect ����

    public MercenaryInfo[] infos;

    private void Awake()
    {
        MercenaryCount = infos.Length;
        save = FindObjectOfType<SaveSystem>();
        storePanel.SetActive(false);
        inventoryPanel.SetActive(false);
    }

    private void OnEnable()
    {
        RectTransform StoreContent = StoreScrollRect.content;
        RectTransform InventoryContent = InventoryScrollRect.content;

        for (int i = 0; i < MercenaryCount; i++)
        {
            StoreContents.Add(Instantiate(mercenaryContent, StoreScrollRect.content));
            StoreContents[i].GetComponent<MercenaryContent>().info = infos[i];
            StoreContents[i].GetComponent<MercenaryContent>().isCanClick = true;

            InventoryContents.Add(Instantiate(mercenaryContent, InventoryScrollRect.content));
            InventoryContents[i].GetComponent<MercenaryContent>().info = infos[i];
        }

        for (int i = 0; i < MercenaryCount; i++)
        {
            numbers.Add(0);
        }

        UpdateCountText();
        LoadData();

        for (int i = 0; i < MercenaryCount; ++i)
        {
            Inventory.Instance.SetInventory(infos[i], numbers[i]); // �κ��丮 set���ֱ�
        }

        collected.info = null;
    }

    public void Purchase()
    {
        MercenaryInfo info = collected.info;
        if (info != null && info.Price <= CashManager.Instance.Cash)
        {
            CashManager.Instance.SpendMoney(info.Price);
            numbers[info.number - 1]++;
            totalCount++;
            SaveData();
        }
        else
        {
            print("������ or info����");
            print(CashManager.Instance.Cash);
        }
    }

    public void NextDay()
    {
        WeekManager.Instance.ResetTimer();
    }

    public void ShowChange(MercenaryInfo info)
    {
        collected.info = info;
        infoImage.sprite = info.MercenarySprite;
        mercenaryName.text = info.MercenaryPrice;
        mercenaryExplain.text = info.MercenaryExplain;
    }

    public void ActiveInventory()
    {
        storePanel.SetActive(false);
        inventoryPanel.SetActive(true);
        UpdateCountText();
    }

    public void ActiveStore()
    {
        storePanel.SetActive(true);
        inventoryPanel.SetActive(false);
    }

    public void InactiveStoreAndInventory()
    {
        storePanel.SetActive(false);
        inventoryPanel.SetActive(false);
    }

    public void UpdateCountText()
    {
        for (int i = 0; i < MercenaryCount; i++)
        {
            InventoryContents[i].GetComponentInChildren<TMP_Text>().text = numbers[i].ToString();
        }
    }

    public void UpdateCashText()
    {
        cashText.text = CashManager.Instance.Cash.ToString()+"원";
    }

    public void SaveData()
    {
        data.gold = CashManager.Instance.Cash;
        for (int i = 0; i < numbers.Count; i++)
        {
            data.cards[i] = numbers[i];
        }

        save.Save(data);
    }

    public void LoadData()
    {
        data = save.Load();
        data.gold = CashManager.Instance.Cash;

        for (int i = 0; i < numbers.Count; i++)
        {
            numbers[i] = data.cards[i];
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MercenaryCollected : MonoSingleton<MercenaryCollected>
{


    [SerializeField] private GameObject Store;
    [SerializeField] private GameObject Inventory;

    [SerializeField] private Image infoImage;
    [SerializeField] private TextMeshProUGUI mercenaryName;
    [SerializeField] private TextMeshProUGUI mercenaryExplain;

    [SerializeField] private MercenaryContent collected;

    public int MercenaryCount = 0;

    //public int[] numbers = { 0, 0, 0, 0, 0, 0 };
    List<int> numbers = new List<int>();
    int totalCount = 0;
    public List<GameObject> StoreContents = new List<GameObject>();
    public List<GameObject> InventoryContents = new List<GameObject>();

    [SerializeField] private GameObject mercenaryContent;

    public ScrollRect StoreScrollRect; // ScrollRect 참조
    public ScrollRect InventoryScrollRect; // ScrollRect 참조

    [SerializeField] MercenaryInfo[] infos;

    private void Awake()
    {
        MercenaryCount = infos.Length;
    }

    private void Start()
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

    }

    public void Purchase()
    {
        MercenaryInfo info = collected.info;
        numbers[info.number - 1]++;
        totalCount++;
    }

    public void goToInventory()
    {
        print("인벤토리로 갈까");
    }

    public void NextDay(MercenaryInfo info)
    {
        print("다음날 레츠고다민");
    }

    public void ShowChange(MercenaryInfo info)
    {
        collected.info = info;
        infoImage.sprite = info.MercenarySprite;
        mercenaryName.text = info.MercenaryPrice;
        mercenaryExplain.text = info.MercenaryExplain;
        print("ShowChange");
    }

    public void ActiveInventory()
    {
        Store.SetActive(false);
        Inventory.SetActive(true);
        UpdateCountText();
    }

    public void ActiveStore()
    {
        Store.SetActive(true);
        Inventory.SetActive(false);
    }

    public void UpdateCountText()
    {
        for (int i = 0; i < MercenaryCount; i++)
        {
            InventoryContents[i].GetComponentInChildren<TMP_Text>().text = numbers[i].ToString();
        }
    }
}

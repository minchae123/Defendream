using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MercenaryCollected : MonoBehaviour
{
    [SerializeField] private List<MercenaryInfo> MercenarysList;

    [SerializeField] private Image infoImage;
    [SerializeField] private TextMeshProUGUI mercenaryName;
    [SerializeField] private TextMeshProUGUI mercenaryExplain;

    [SerializeField] private MercenaryContent collected;

    private void Awake()
    {

    }

    public void Purchase()
    {
        MercenaryInfo info = collected.info;
        MercenarysList.Add(info);
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
}

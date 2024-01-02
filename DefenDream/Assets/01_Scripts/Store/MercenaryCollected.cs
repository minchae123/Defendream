using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MercenaryCollected : MonoBehaviour
{
    [SerializeField] private List<MercenaryInfo> planets;

    [SerializeField] private Image infoImage;
    [SerializeField] private TextMeshProUGUI mercenaryName;
    [SerializeField] private TextMeshProUGUI mercenaryExplain;

    [SerializeField] private MercenaryContent collected;

    private void Awake()
    {

    }

    public void AddCollected(MercenaryInfo info)
    {

    }

    public void ShowChange(MercenaryInfo info)
    {
        infoImage.sprite = info.MercenarySprite;
        mercenaryName.text = info.MercenaryPrice;
        mercenaryExplain.text = info.MercenaryExplain;
        print("ShowChange");
    }

    public void ShowReset()
    {
        infoImage.sprite = null;
        mercenaryName.text = "???";
        mercenaryExplain.text = "??????????";
    }
}

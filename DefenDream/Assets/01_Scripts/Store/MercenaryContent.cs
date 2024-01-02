using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MercenaryContent : MonoBehaviour, IPointerClickHandler
{
    private MercenaryCollected mercenaryCollected;
    [SerializeField] private MercenaryInfo info;
    [SerializeField] private Image mercenaryImage;

    private void Awake()
    {
        mercenaryCollected = FindObjectOfType<MercenaryCollected>();

    }

    private void Start()
    {
        mercenaryImage.sprite = info.MercenarySprite;
        info.MercenaryPrice = info.Price.ToString() + "��";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        mercenaryCollected.ShowChange(info);
    }
}

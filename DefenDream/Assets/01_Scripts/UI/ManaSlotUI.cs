using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ManaSlotUI : MonoBehaviour
{
    [SerializeField] private Image manaImage;

    public void WaitUpdating(float scale)
    {
        manaImage.color = Color.gray;
        transform.localScale = new Vector3(scale, 1, 1);
    }
    public void FinishUpdating(int currentMana)
    {
        int slotNum = currentMana - 1;
        manaImage.transform.DOScale(1.1f, 0.12f).SetEase(Ease.OutBounce)
            .OnComplete(() => manaImage.transform.DOScale(1f, 0.1f).SetEase(Ease.OutBounce)).OnComplete(() => UpdateSlot(currentMana, slotNum));
    }
    public void CleanUpSlot()
    {
        transform.localScale = Vector3.zero;
    }
    public void UpdateSlot(int currentMana, int slotNum)
    {
        if(currentMana < slotNum + 1)
        {
            return;
        }
        transform.localScale = Vector3.one;
        manaImage.color = new Color(0f, 1f - ((slotNum + 1f) * 0.1f), 1f); // 0~9
    }
}

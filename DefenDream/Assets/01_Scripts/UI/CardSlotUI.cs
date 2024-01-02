using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class CardSlotUI : MonoBehaviour, IPointerClickHandler
{
    public TestSO CurrentCard;
    private int requiredMana;
    private bool canSelected = false;

    [Header("UI")]
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI manaText;
    [SerializeField] private GameObject enoughPanel;

    #region clickEvent
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!canSelected) return;
        CardUI.Instance.UpdateSelectSlot(this); // 터치했다고 알려주기
    }
    public void AddClickHistroy()
    {
        transform.DOLocalMoveY(-190f, 1f);
    }
    public void ClearClickHistory()
    {
        transform.DOLocalMoveY(-240f, 1f);
    }
    #endregion

    public void ClearSlot()
    {
        iconImage.sprite = null;
        manaText.text = string.Empty;
        enoughPanel.SetActive(true);
    }
    public void UpdateSlot()
    {
        if (CurrentCard == null) return;
        requiredMana = CurrentCard.mana;

        iconImage.sprite = CurrentCard.icon;
        manaText.text = $"{requiredMana}";
    }
    public void CheckCanSelect(int currentMana)
    {
        if (currentMana >= requiredMana)// 현재 가지고 있는 마나가 필요한 마나보다 많거나 같을 경ㅇ우
        {
            canSelected = true;
            enoughPanel.SetActive(false);
        }
        else canSelected = false;
    }
}

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
    public int RequiredMana => requiredMana;
    private bool canSelected = false;
    private bool iscanSelectedFirst = false;

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
        transform.DOLocalMoveY(-330f, 0.3f);
    }
    public void ClearClickHistory()
    {
        transform.DOLocalMoveY(-360f, 0.3f);
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

        CheckCanSelect();
    }
    public void CheckCanSelect()
    {
        int currentMana = ManaUI.Instance.CurrentMana;
        if (currentMana >= requiredMana)// 현재 가지고 있는 마나가 필요한 마나보다 많거나 같을 경ㅇ우
        {
            canSelected = true;
            enoughPanel.SetActive(false);

            // 그냥 예쁘게 하려고
            if(iscanSelectedFirst)
            {
                iscanSelectedFirst = false;
                transform.DOScale(1.1f, 0.15f).OnComplete(() => transform.DOScale(1, 0.1f));
            }
        }
        else
        {
            canSelected = false;
            iscanSelectedFirst = true;

            ClearClickHistory();
            CardUI.Instance.ResetSelectSlot(this);
            enoughPanel.SetActive(true);
        }
    }
}

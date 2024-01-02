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

    [Header("UI")]
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI manaText;
    [SerializeField] private GameObject enoughPanel;

    #region clickEvent
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!canSelected) return;
        CardUI.Instance.UpdateSelectSlot(this); // ��ġ�ߴٰ� �˷��ֱ�
    }
    public void AddClickHistroy()
    {
        transform.DOLocalMoveY(-330f, 0/3f);
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
    }
    public void CheckCanSelect(int currentMana)
    {
        if (currentMana >= requiredMana)// ���� ������ �ִ� ������ �ʿ��� �������� ���ų� ���� �椷��
        {
            canSelected = true;
            enoughPanel.SetActive(false);
        }
        else
        {
            canSelected = false;
            ClearClickHistory();
            CardUI.Instance.ResetSelectSlot(this);
            enoughPanel.SetActive(true);
        }
    }
}

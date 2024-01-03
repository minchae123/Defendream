using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using System.Collections.Generic;

public class CardSlotUI : MonoBehaviour, IPointerClickHandler
{
    public CardSO currentCard;
    private int requiredMana;
    
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
        CardUI.Instance.UpdateSelectSlot(this); // ��ġ�ߴٰ� �˷��ֱ�
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
        if (currentCard == null) return;
        requiredMana = currentCard.mana;

        iconImage.sprite = currentCard.icon;
        manaText.text = $"{requiredMana}";

        CheckCanSelect();
    }
    public void CheckCanSelect()
    {
        int currentMana = ManaUI.Instance.CurrentMana;
        if (currentMana >= requiredMana)// ���� ������ �ִ� ������ �ʿ��� �������� ���ų� ���� �椷��
        {
            canSelected = true;
            enoughPanel.SetActive(false);

            // �׳� ���ڰ� �Ϸ���
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

    public void CreateArmy(Vector3 hit)
    {
        Instantiate(currentCard.prefab, new Vector3(hit.x, hit.y + 1, hit.z), Quaternion.identity);
        UsingItem();
        SetRandomCard();

        ClearClickHistory();
        CardUI.Instance.ResetSelectSlot();
    }
    public void UsingItem()
    {
        ManaUI.Instance.UseMana(requiredMana);
        Inventory.Instance.UseInventory(currentCard);
    }
    public void SetRandomCard()
    {
        Dictionary<CardSO, int> cardInven = Inventory.Instance.cardInventory; // �κ��丮���� ��������
        List<CardSO> randomCards = new List<CardSO>(); // ���� ��� ������ ī�带 ã�Ƴ�

        foreach (var card in cardInven) // �κ��丮���ִ� ī��
        {
            if (card.Value > 0) // ���� ī�� ������ 0���� ŭ
            {
                randomCards.Add(card.Key); // ��� ����
            }
        }
        // ��� ������ ī�尡 ���ٸ� �̺� ����(���߿�)
        if (randomCards.Count == 0)
        {
            return;
        }

        int randomIndex = Random.Range(0, randomCards.Count); 
        CardSO selectCard = randomCards[randomIndex];
        currentCard = selectCard;
    }
}

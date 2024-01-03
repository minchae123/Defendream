using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class NextCardSlot : MonoBehaviour
{
    public CardSO nextCard;

    [Header("UI")]
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI manaText;

    private void Start()
    {
        SetNextCard(); // ó���� �������� ���� ī�� ����
    }

    public void SetNextCard()
    {
        transform.DOScale(0.8f, 0.2f).OnComplete(() => transform.DOScale(1, 0.15f));
        SetRandomCard();
        ClearSlot();
        UpdateSlot();
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
        nextCard = selectCard;
    }
    public void ClearSlot()
    {
        iconImage.sprite = null;
        manaText.text = string.Empty;
    }
    public void UpdateSlot()
    {
        if (nextCard == null) return;
        iconImage.sprite = nextCard.icon;
        manaText.text = $"{nextCard.mana}";
    }
}

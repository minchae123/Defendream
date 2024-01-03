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
        SetNextCard(); // 처음에 랜덤으로 다음 카드 결정
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
        Dictionary<CardSO, int> cardInven = Inventory.Instance.cardInventory; // 인벤토리에서 가져오고
        List<CardSO> randomCards = new List<CardSO>(); // 현재 사용 가능한 카드를 찾아냄

        foreach (var card in cardInven) // 인벤토리에있는 카드
        {
            if (card.Value > 0) // 만약 카드 개수가 0보다 큼
            {
                randomCards.Add(card.Key); // 사용 가능
            }
        }
        // 사용 가능한 카드가 없다면 쫄병 생성(나중에)
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

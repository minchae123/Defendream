using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUI : MonoBehaviour
{
    public static CardUI Instance;

    [SerializeField] private Transform slotparent;
    [SerializeField] private CardSlotUI[] cardSlots;

    private CardSlotUI selectedSlot;

    private void Awake()
    {
        if (Instance != null) print("CardUIManager Error");
        Instance = this;
        cardSlots = slotparent.GetComponentsInChildren<CardSlotUI>();
    }

    private void Start()
    {
        UpdateSlot();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                if (selectedSlot != null && selectedSlot.CurrentCard != null)
                {
                    Instantiate(selectedSlot.CurrentCard.prefab, hit.point, Quaternion.identity);
                }
            }
        }
    }

    public void UpdateSelectSlot(CardSlotUI slot)
    {
        slot.AddClickHistroy();
        if (selectedSlot == null) // �ƹ��͵� ���� �� �� ����
        {
            selectedSlot = slot;
            return;
        }
        else if (slot == selectedSlot) // ���� �� �� Ŭ��
        {
            selectedSlot.ClearClickHistory();
            selectedSlot = null;
            return;
        }
        // ���� ���õ� �� �־��� ���
        selectedSlot.ClearClickHistory();
        selectedSlot = slot;
    }
    public void UpdateSlot()
    {
        for (int i = 0; i < cardSlots.Length; ++i)
        {
            cardSlots[i].ClearSlot();
        }
        for (int i = 0; i < cardSlots.Length; ++i)
        {
            cardSlots[i].UpdateSlot();
            cardSlots[i].CheckCanSelect(ManaUI.Instance.CurrentMana);
        }
    }
}

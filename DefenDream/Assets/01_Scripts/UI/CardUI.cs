using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardUI : MonoBehaviour
{
    public static CardUI Instance;
    private SaveSystem save;

	[SerializeField] private LayerMask whatIsGround;

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
        save = FindObjectOfType<SaveSystem>();
        UpdateSlot();   
    }

    private void Update()
    {   
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, whatIsGround))
            {
                if (selectedSlot != null && selectedSlot.currentCard != null)
                {
                    selectedSlot.CreateArmy(hit.point); // ����!]
                    UpdateSlot(); // ����
                }
            }
        }
    }

    public void ResetSelectSlot(CardSlotUI slot)
    {
        if(slot == selectedSlot)
        {
            selectedSlot.ClearClickHistory();
            selectedSlot = null;
        }
    }
    public void ResetSelectSlot()
    {
        selectedSlot = null;
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
            ResetSelectSlot(slot);
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
        }
    }
}

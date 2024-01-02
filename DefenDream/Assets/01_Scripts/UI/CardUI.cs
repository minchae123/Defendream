using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                print(hit.collider.gameObject.layer);
                if (selectedSlot != null && selectedSlot.CurrentCard != null)
                {
                    Instantiate(selectedSlot.CurrentCard.prefab, new Vector3(hit.point.x, hit.point.y + 1, hit.point.z), Quaternion.identity);
                    ManaUI.Instance.UseMana(selectedSlot.RequiredMana);
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

    public void UpdateSelectSlot(CardSlotUI slot)
    {
        slot.AddClickHistroy();
        if (selectedSlot == null) // 아무것도 선택 안 된 상태
        {
            selectedSlot = slot;
            return;
        }
        else if (slot == selectedSlot) // 같은 거 또 클릭
        {
            ResetSelectSlot(slot);
            return;
        }
        // 만약 선택된 게 있었을 경우
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

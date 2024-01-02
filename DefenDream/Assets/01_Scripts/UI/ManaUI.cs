using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaUI : MonoBehaviour
{
    public static ManaUI Instance;

    [SerializeField] private Transform manaParent;
    [SerializeField] private ManaSlotUI[] manaSlots;

    private int currentMana = 10;
    public int CurrentMana => currentMana;
    private int maxMana = 10;
    private float delayTime = 2f;

    private void Awake()
    {
        if (Instance != null) print("manauimanager error");
        Instance = this;

        manaSlots = manaParent.GetComponentsInChildren<ManaSlotUI>(); // 0 ~ 9
        currentMana = 10; // 기본 마나 10
    }

    private void Start()
    {
        UpdateManaSlot();

        StartCoroutine(UpdateCoroutine());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UseMana(2); 
        }
    }

    private IEnumerator UpdateCoroutine()
    {
        if(currentMana == maxMana)
        {
            //print("Ddd");
            yield return new WaitUntil(() => currentMana != maxMana); // 같아지지 않을때까지 대기
        }

        float currentTime = 0f;
        while(currentTime <= delayTime)
        {
            currentTime += Time.deltaTime;
            manaSlots[currentMana].WaitUpdating(currentTime / delayTime);
            yield return null;
        }

        ++currentMana; // 시간 지났으면 ++
        currentMana = Mathf.Clamp(currentMana, 0, maxMana);

        UpdateManaSlot();

        yield return null;
        StartCoroutine(UpdateCoroutine());
    }

    private void UpdateManaSlot()
    {
        CardUI.Instance.UpdateSlot(); // 마나 업데이트 하면서 카드도 업데이트 해줘

        for (int i = 0; i < manaSlots.Length; ++i)
        {
            manaSlots[i].CleanUpSlot();
        }
        for (int i = 0; i < manaSlots.Length; ++i)
        {
            manaSlots[i].UpdateSlot(currentMana, i);
        }
    }

    public void UseMana(int cnt)
    {
        if (currentMana - cnt >= 0)
        {
            currentMana -= cnt;
            UpdateManaSlot();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ManaUI : MonoBehaviour
{
    public static ManaUI Instance;

    [SerializeField] private Transform manaImage;
    [SerializeField] private Transform manaParent;
    [SerializeField] private ManaSlotUI[] manaSlots;

    private int currentMana = 10;
    public int CurrentMana => currentMana;
    private int maxMana = 10;
    [SerializeField] private float delayTime = 2f;

    private void Awake()
    {
        if (Instance != null) print("manauimanager error");
        Instance = this;

        manaSlots = manaParent.GetComponentsInChildren<ManaSlotUI>(); // 0 ~ 9
        currentMana = 10; // �⺻ ���� 10
    }

    private void Start()
    {
        UpdateManaSlot();

        StartCoroutine(UpdateCoroutine());
    }

    private IEnumerator UpdateCoroutine()
    {
        if(currentMana == maxMana)
        {
            //print("Ddd");
            yield return new WaitUntil(() => currentMana != maxMana); // �������� ���������� ���
        }

        float currentTime = 0f;
        while(currentTime <= delayTime)
        {
            currentTime += Time.deltaTime;
            manaSlots[currentMana].WaitUpdating(currentTime / delayTime);
            yield return null;
        }

        ++currentMana; // �ð� �������� ++
        currentMana = Mathf.Clamp(currentMana, 0, maxMana);

        UpdateManaSlot();
        manaSlots[currentMana - 1].FinishUpdating(currentMana);

        manaImage.DOScale(1.1f, 0.2f).OnComplete(() => manaImage.DOScale(1f, 0.1f));
        yield return null;
        StartCoroutine(UpdateCoroutine());
    }

    private void UpdateManaSlot()
    {
        CardUI.Instance.UpdateSlot(); // ���� ������Ʈ �ϸ鼭 ī�嵵 ������Ʈ ����

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

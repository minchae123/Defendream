using DayEnum;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Diary : MonoSingleton<Diary>
{
    [SerializeField] private List<bool> goodOrBad;

    [Header("Main")]
    public MainDiarySO mainDiarySO;

    [SerializeField] private Transform pageParent;
    [SerializeField] private DiaryPage[] pages;

    [Header("UI")]
    [SerializeField] private GameObject leftButton;
    [SerializeField] private GameObject rightButton;

    private int currentPage = 0;

    private void Awake()
    {
        pages = pageParent.GetComponentsInChildren<DiaryPage>();
        currentPage = 0;
    }

    private void Start()
    {
        for(int i = 0; i < 7; ++i)
        {
            goodOrBad.Add(Random.Range(0, 2) == 0);
        }

        OnClickButton();
        UpdatePage((WhatDay)currentPage);
    }

    #region ��ư Ŭ��
    public void OnClickButton()
    {
        leftButton.SetActive(currentPage > 0);
        rightButton.SetActive(currentPage < 6);
    }
    public void OnClickLeftButton() 
    {
        currentPage -= 2;
        currentPage = Mathf.Clamp(currentPage, 0, 6);

        UpdatePage((WhatDay)currentPage);
    }
    public void OnClickRightButton()
    {
        currentPage += 2;
        currentPage = Mathf.Clamp(currentPage, 0, 6);

        UpdatePage((WhatDay)currentPage);
    }
    #endregion


    public void UpdatePage(WhatDay today) // ���þ������� // �� (0) ȭ (1) �� (2)
    {
        for(int i = 0; i < pages.Length; ++i)
        {
            pages[i].ClearPage();
        }
        for(int i = 0; i < pages.Length; ++i)
        {
            if (goodOrBad.Count <= currentPage + i) return;

            pages[i].UpdatePage(i % 2 == 0 ? currentPage : currentPage + 1,
                i % 2 == 0 ? goodOrBad[currentPage] : goodOrBad[currentPage + 1]);
        }
    }
}

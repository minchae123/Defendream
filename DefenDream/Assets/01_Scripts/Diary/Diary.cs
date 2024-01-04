using DayEnum;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Diary : MonoSingleton<Diary>
{
    [SerializeField] private List<bool> goodOrBad;

    [Header("Main")]
    public DiarySO mainDiarySO;

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
            goodOrBad.Add(true);
        }

        OnClickButton();
        UpdatePage();
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
        UpdatePage();
    }
    public void OnClickRightButton()
    {
        currentPage += 2;
        currentPage = Mathf.Clamp(currentPage, 0, 6);
        UpdatePage();
    }
    #endregion

    public void UpdatePage() // ���þ������� // �� (0) ȭ (1) �� (2)
    {
        int pageIndex = currentPage;
        // �ʱ�ȭ
        pages[0].ClearPage();
        pages[0].UpdatePage(pageIndex, goodOrBad[pageIndex]);
        pages[1].ClearPage();

        if (++pageIndex > (int)WhatDay.Sunday)
        {
            pages[1].LoadGameOverPanel();
            return;
        }
        pages[1].UpdatePage(pageIndex, goodOrBad[pageIndex]);
    }
}

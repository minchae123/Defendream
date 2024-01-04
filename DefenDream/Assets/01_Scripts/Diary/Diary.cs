using DayEnum;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class Diary : MonoSingleton<Diary>
{
    //[SerializeField] private List<bool> goodOrBad;
    [SerializeField] private CheckWeekSO checkWeekSO;
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
        OnClickButton();
        UpdatePage();
    }

    #region 버튼 클릭
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

    public void UpdatePage() // 오늘언제인지 // 월 (0) 화 (1) 수 (2)
    {
        int pageIndex = currentPage;
        // 초기화
        pages[0].ClearPage();
        pages[0].UpdatePage(pageIndex, checkWeekSO.goodOrBad[pageIndex]);
        pages[1].ClearPage();

        if (++pageIndex > (int)WhatDay.Saturday)
        {
            pages[1].LoadGameOverPanel();
            return;
        }
        pages[1].UpdatePage(pageIndex, checkWeekSO.goodOrBad[pageIndex]);
    }

    public void GoStart()
	{
        SceneManager.LoadScene(0);
	}

    public void ReGame()
	{
        SceneManager.LoadScene(1);
	}
}

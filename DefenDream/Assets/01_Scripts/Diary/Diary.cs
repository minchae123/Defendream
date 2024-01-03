using DayEnum;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Diary : MonoSingleton<Diary>
{
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
        // true false 받아오기 -> 이건 뭐... JSOn으로 해도 되고 
        UpdatePage(true);

        OnClickButton();
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

        UpdatePage(true);
    }
    public void OnClickRightButton()
    {
        currentPage += 2;
        currentPage = Mathf.Clamp(currentPage, 0, 6);

        UpdatePage(false);
    }
    #endregion

    public void UpdatePage(bool value)
    {
        for(int i = 0; i < pages.Length; ++i)
        {
            pages[i].ClearPage();
        }
        for(int i = 0; i < pages.Length; ++i)
        {
            pages[i].UpdatePage(i % 2 == 0 ? currentPage : currentPage+1, value);
        }
    }
}

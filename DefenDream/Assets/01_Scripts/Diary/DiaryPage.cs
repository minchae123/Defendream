using DayEnum;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiaryPage : MonoBehaviour
{
    [SerializeField] private WhatDay currentDay = WhatDay.None;

    //int 형식에 [today] 번째 저장된 게 있다면 그거 로드해주기
    private Dictionary<int, DayDiaryClass> currentDiary = new Dictionary<int, DayDiaryClass>();

    [Header("Panel")]
    [SerializeField] private GameObject gameOverPanel;
    [Header("Diary")]
    [SerializeField] private Image thisImage;
    [SerializeField] private Image diaryPainting;
    [SerializeField] private TextMeshProUGUI diaryText;
    [SerializeField] private TextMeshProUGUI todayText;

    public void ClearPage()
    {
        currentDay = WhatDay.None;

        gameOverPanel.SetActive(false);
        diaryPainting.gameObject.SetActive(true);

        diaryPainting.sprite = null;
        diaryText.text = todayText.text = string.Empty;
        thisImage.color = Color.black;
    }
    public void UpdatePage(int today, bool value)
    {
        currentDay = (WhatDay)today;
        thisImage.color = Color.white;

        if (currentDiary.ContainsKey(today)) // 이미 기록이 있는 경우
        {
            ReloadPage(today);
            return;
        }

        // true -> goodDay, false -> badDay
        List<DayDiaryClass> todayMoodList = new List<DayDiaryClass>(value ? Diary.Instance.mainDiarySO.goodDayList : Diary.Instance.mainDiarySO.badDayList);

        //print((WhatDay)today);
        if (todayMoodList.Count > 0)
        {
            List<DayDiaryClass> finalDiaryList = new List<DayDiaryClass>(todayMoodList.Count);
            foreach (var exist in todayMoodList)
            {
                if (!exist.IsUsed) // 사용하지 않았다면?
                {
                    finalDiaryList.Add(exist); // 리스트에 추가
                }
            }

            if (finalDiaryList.Count > 0) // 있다면
            {
                int randomIndex = Random.Range(0, finalDiaryList.Count);

                var selectedDiary = finalDiaryList[randomIndex];
                finalDiaryList[randomIndex].IsUsed = true;
                //print($"{today}: {selectedDiary.text}");

                currentDiary.Add(today, selectedDiary);

                diaryPainting.sprite = selectedDiary.painting;
                diaryText.text = selectedDiary.text;

                UpdateText();
            }
        }
    }

    public void UpdateText()
    {
        switch (currentDay)
        {
            case WhatDay.Monday:
                todayText.text = "월요일 일기";
                break;
            case WhatDay.Tuesday:
                todayText.text = "화요일 일기";
                break;
            case WhatDay.Wednesday:
                todayText.text = "수요일 일기";
                break;
            case WhatDay.Thursday:
                todayText.text = "목요일 일기";
                break;
            case WhatDay.Friday:
                todayText.text = "금요일 일기";
                break;
            case WhatDay.Saturday:
                todayText.text = "토요일 일기";
                break;
            case WhatDay.Sunday:
                todayText.text = "일요일 일기";
                break;
            case WhatDay.None:
                break;
        }
    }
    public void LoadGameOverPanel()
    {
        ClearPage();
        diaryPainting.gameObject.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    private void ReloadPage(int today)
    {
        //print("ReloadSuccess");
        UpdateText();
        diaryPainting.sprite = currentDiary[today].painting;
        diaryText.text = currentDiary[today].text;
    }
}

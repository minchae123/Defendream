using DayEnum;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiaryPage : MonoBehaviour
{
    private WhatDay currentDay = WhatDay.None;
    //int 형식에 [today] 번째 저장된 게 있다면 그거 로드해주기
    private Dictionary<int, DayDiaryClass> currentDiary = new Dictionary<int, DayDiaryClass>();

    [SerializeField] private Image diaryPainting;
    [SerializeField] private TextMeshProUGUI diaryText;

    public void ClearPage()
    {
        diaryPainting.sprite = null;
        diaryText.text = string.Empty;
    }
    public void UpdatePage(int today, bool value)
    {
        currentDay = (WhatDay)today;

        if (currentDay < WhatDay.Monday || currentDay > WhatDay.Sunday)
        {
            return;
        }

        if (currentDiary.ContainsKey(today))// 존재여부 판단
        {     
            ReloadPage(today);
            return;
        }        

        foreach (var diary in Diary.Instance.mainDiarySO.mainDiary)
        {
            if (diary.today == currentDay) // 현재 넘버와 같은 diary 뽑아오기
            {
                //print($"{diary.today}: 성공");
                var dayList = value ? diary.diarySO.goodDayList : diary.diarySO.badDayList;
                int idx = Random.Range(0, dayList.Count);
                currentDiary[today] = dayList[idx];

                diaryPainting.sprite = dayList[idx].painting;
                diaryText.text = dayList[idx].text;

                return;
            }
        }
    }

    private void ReloadPage(int today)
    {
        //print("ReloadSuccess");
        diaryPainting.sprite = currentDiary[today].painting;
        diaryText.text = currentDiary[today].text;
    }
}

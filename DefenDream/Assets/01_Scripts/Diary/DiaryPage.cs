using DayEnum;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiaryPage : MonoBehaviour
{
    private WhatDay currentDay = WhatDay.None;
    //int ���Ŀ� [today] ��° ����� �� �ִٸ� �װ� �ε����ֱ�
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

        if (currentDiary.ContainsKey(today))// ���翩�� �Ǵ�
        {     
            ReloadPage(today);
            return;
        }        

        foreach (var diary in Diary.Instance.mainDiarySO.mainDiary)
        {
            if (diary.today == currentDay) // ���� �ѹ��� ���� diary �̾ƿ���
            {
                //print($"{diary.today}: ����");
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

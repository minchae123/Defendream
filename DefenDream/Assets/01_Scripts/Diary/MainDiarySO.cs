using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DayEnum;

[System.Serializable]
public class MainDiaryClass
{
    public WhatDay today;
    public DayDiarySO diarySO;
}
[CreateAssetMenu(menuName = "SO/Diary/MainDiary")]
public class MainDiarySO : ScriptableObject
{
    public List<MainDiaryClass> mainDiary;
}

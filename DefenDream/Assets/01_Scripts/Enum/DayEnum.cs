using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DayEnum
{
    [System.Serializable]
    public enum WhatDay // ��/ȭ����� �̷� ��... ����������
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        None
    }
    [System.Serializable]
    public enum DayType // ���� ���� ������ �� ������ 
    {
        GoodDay,
        BadDay
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DayEnum
{
    [System.Serializable]
    public enum WhatDay // ��/ȭ����� �̷� ��... ����������
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday,
        None
    }
    [System.Serializable]
    public enum DayType // ���� ���� ������ �� ������ 
    {
        GoodDay,
        BadDay
    }
}

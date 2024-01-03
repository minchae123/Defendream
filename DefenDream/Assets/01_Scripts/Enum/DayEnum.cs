using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DayEnum
{
    [System.Serializable]
    public enum WhatDay // 월/화수목금 이런 거... 언제날인지
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
    public enum DayType // 오늘 날이 좋은지 안 좋은지 
    {
        GoodDay,
        BadDay
    }
}

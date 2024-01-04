using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DayEnum
{
    [System.Serializable]
    public enum WhatDay // 월/화수목금 이런 거... 언제날인지
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
    public enum DayType // 오늘 날이 좋은지 안 좋은지 
    {
        GoodDay,
        BadDay
    }
}

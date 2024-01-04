using UnityEngine;
using DayEnum;
using System.Collections.Generic;

[System.Serializable]
public class DayDiaryClass
{
    [HideInInspector] public DayType dayType; // 좋은 날인지 나쁜 날인지

    public Sprite painting; // 그림
    [TextArea] public string text; // 일기
    public bool IsUsed = false;
}

[CreateAssetMenu(menuName ="SO/Diary")]
public class DiarySO : ScriptableObject
{
    public List<DayDiaryClass> goodDayList;
    public List<DayDiaryClass> badDayList;

    private void OnEnable()
    {
        // 처음에 초기하ㅗ
        foreach(var list in goodDayList)
        {
            list.dayType = DayType.GoodDay;
            list.IsUsed = false;
        }

        foreach (var list in goodDayList)
        {
            list.dayType = DayType.BadDay;
            list.IsUsed = false;
        }
    }
}

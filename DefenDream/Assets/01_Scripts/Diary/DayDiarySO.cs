using UnityEngine;
using DayEnum;
using System.Collections.Generic;

[System.Serializable]
public class DayDiaryClass
{
    [HideInInspector] public DayType dayType; // ���� ������ ���� ������

    public Sprite painting; // �׸�
    [TextArea] public string text; // �ϱ�
}

[CreateAssetMenu(menuName ="SO/Diary/Day")]
public class DayDiarySO : ScriptableObject
{
    public List<DayDiaryClass> goodDayList;
    public List<DayDiaryClass> badDayList;

    private void OnEnable()
    {
        // ó���� �ʱ��Ϥ�
        foreach(var list in goodDayList)
        {
            list.dayType = DayType.GoodDay;
        }

        foreach (var list in goodDayList)
        {
            list.dayType = DayType.BadDay;
        }
    }
}

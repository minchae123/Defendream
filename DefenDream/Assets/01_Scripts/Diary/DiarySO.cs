using UnityEngine;
using DayEnum;
using System.Collections.Generic;

[System.Serializable]
public class DayDiaryClass
{
    [HideInInspector] public DayType dayType; // ���� ������ ���� ������

    public Sprite painting; // �׸�
    [TextArea] public string text; // �ϱ�
    public bool IsUsed = false;
}

[CreateAssetMenu(menuName ="SO/Diary")]
public class DiarySO : ScriptableObject
{
    public List<DayDiaryClass> goodDayList;
    public List<DayDiaryClass> badDayList;

    private void OnEnable()
    {
        // ó���� �ʱ��Ϥ�
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

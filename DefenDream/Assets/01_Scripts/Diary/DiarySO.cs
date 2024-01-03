using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DayEnum;

[System.Serializable]
public class Diary
{
    public DayType dayType; // 좋은 날인지 나쁜 날인지
    public Sprite painting; // 그림
    public string text; // 일기 
}
[CreateAssetMenu(menuName = "SO/Diary")]
public class DiarySO : ScriptableObject
{
    public List<Diary> diary;       
}

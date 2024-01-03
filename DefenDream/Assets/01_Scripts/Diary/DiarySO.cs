using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DayEnum;

[System.Serializable]
public class Diary
{
    public DayType dayType; // ���� ������ ���� ������
    public Sprite painting; // �׸�
    public string text; // �ϱ� 
}
[CreateAssetMenu(menuName = "SO/Diary")]
public class DiarySO : ScriptableObject
{
    public List<Diary> diary;       
}

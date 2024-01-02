using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Test")]
public class TestSO : ScriptableObject
{
    //needed
    //public string name;
    public int mana;
    // UI
    public Sprite icon;
    // Scene
    public GameObject prefab;
}

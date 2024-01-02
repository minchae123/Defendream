using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PlayerType")]
public class PlayerTypeSO : ScriptableObject
{
    public string _name;

    public float _Hp;
    public float _AttackDamage;
    public float _AttackDistance;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using playerType;

namespace playerType
{
    public enum pTypeEnum
    {
        Tanker,
        Melee,
        Archer,
        Magic
    }
}

[CreateAssetMenu(menuName = "SO/PlayerType")]
public class PlayerTypeSO : ScriptableObject
{
    public pTypeEnum _pType;

    public string _name;

    public float _Hp;
    public float _AttackDamage;
    public float _AttackDistance;
}

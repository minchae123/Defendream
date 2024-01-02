using UnityEngine;
using EnemyEnum;

[CreateAssetMenu(menuName = "SO/EnemyType")]
public class EnemyTypeSO : ScriptableObject
{
    public EnemyType _eType;

    public Material _material;

    public string _EnemyName;

    public float _EnemyHp;
    public float _AttackDamage;
    public float _AttackDistance;
}

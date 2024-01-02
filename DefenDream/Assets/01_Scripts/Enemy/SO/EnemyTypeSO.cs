using UnityEngine;
using EnemyEnum;

[CreateAssetMenu(menuName = "SO/EnemyType")]
public class EnemyTypeSO : ScriptableObject
{
    public EnemyType _eType;

    public Material _material;

    public string _EnemyName;

    public int _EnemyHp;
    public int _AttackDamage;
    public int _AttackDistance;
}

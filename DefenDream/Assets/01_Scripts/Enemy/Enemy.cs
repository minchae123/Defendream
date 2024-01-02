using EnemyEnum;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyTypeSO[] _eTypeSO;
    [SerializeField] private float _spawnTime;

    [HideInInspector] public EnemyTypeSO _eType;
    [HideInInspector] public EnemyType TypeEnum;

    private float time = 0;

    private void Awake()
    {
        SelectType();
    }

    private int RandomSpawn()
    {
        int i = Random.Range(0, 3);

        return i;
    }

    private void SelectType()
    {
        switch ((EnemyType)RandomSpawn())
        {
            case EnemyType.Melee:
                {
                    print("근거리");
                    Melee();
                    _eType = _eTypeSO[(int)EnemyType.Melee];
                }
                break;
            case EnemyType.Range:
                {
                    print("원거리");
                    Range();
                    _eType = _eTypeSO[(int)EnemyType.Range];
                }
                break;
            case EnemyType.Magic:
                {
                    print("마법");
                    Magic();
                    _eType = _eTypeSO[(int)EnemyType.Magic];
                }
                break;
            default:
                break;
        }
    }

    private void Melee()
    {
        TypeEnum = EnemyType.Melee;
    }

    private void Range()
    {
        TypeEnum = EnemyType.Range;
    }

    private void Magic()
    {
        TypeEnum = EnemyType.Magic;
    }
}
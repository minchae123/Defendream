using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyEnum;

public class EnemyAttack: MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private EnemyMovement _enemyMove;

    private EnemyTypeSO _eType;
    private float _saveSpeed;

    private void Awake()
    {
        _eType = _enemy._eType;
        _saveSpeed = _enemyMove._speed;
    }

    private void Update()
    {
        Distance();
    }

    private void Distance()
    {
        float dis = Vector3.Distance(GameManager.instance._player.position, transform.position);

        if (_eType._AttackDistance >= dis)
        {
            _enemyMove._speed = 0;
            Att();
        }
        else
            _enemyMove._speed = _saveSpeed;
    }

    private void Att()
    {
        switch (_enemy.TypeEnum)
        {
            case EnemyType.Melee:
                {

                }
                break;
            case EnemyType.Range:
                {

                }
                break;
            case EnemyType.Magic:
                {

                }
                break;
            default:
                break;
        }
    }
}

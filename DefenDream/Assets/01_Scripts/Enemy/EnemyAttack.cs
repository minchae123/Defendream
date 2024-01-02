using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyEnum;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private EnemyMovement _enemyMove;
    [SerializeField] private Bullet _bulletPrefabs;

    private EnemyTypeSO _eType = null;
    private float _saveSpeed;
    private bool _isAtt = false;

    private void Start()
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
        float dis = Vector3.Distance(GameManager.instance._playerTrm.position, transform.position);

        if (_eType._AttackDistance >= dis && !_isAtt)
        {
            _enemyMove._speed = 0;
            Att();
            _isAtt = true;
        }

        if(_eType._AttackDistance < dis)
            _enemyMove._speed = _saveSpeed;
    }

    private void Att()
    {
        switch (_enemy.TypeEnum)
        {
            case EnemyType.Melee:
                {
                    StartCoroutine(Melee());
                }
                break;
            case EnemyType.Range:
                {
                    StartCoroutine(Range());
                }
                break;
            case EnemyType.Magic:
                {
                    StartCoroutine(Magic());
                }
                break;
            default:
                break;
        }
    }

    IEnumerator Melee()
    {
        while (true)
        {
            //애니메이션 하고~
            //playerHp 깎기

            float damage = _enemy._eType._AttackDamage;

            GameManager.instance._player._hp -= damage;

            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator Range()
    {
        while (true)
        {
            //애니메이션 하고~
            //playerHp 깎기, 총알 발사
            Instantiate(_bulletPrefabs);
            _bulletPrefabs.transform.position = transform.position;

            yield return new WaitForSeconds(3f);
        }
    }

    IEnumerator Magic()
    {
        while (true)
        {
            //애니메이션 하고~
            //playerHp 깎기
            Instantiate(_bulletPrefabs);
            _bulletPrefabs.transform.position = transform.position;

            float damage = _enemy._eType._AttackDamage;

            if (_bulletPrefabs._isCol)
                GameManager.instance._player._hp -= damage;

            yield return new WaitForSeconds(3f);
        }
    }
}

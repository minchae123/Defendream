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
        if (_eType._AttackDistance >= _enemyMove._dis && !_isAtt && _enemyMove._dis != 0)
        {
            _enemyMove._speed = 0;

            Att();
            _isAtt = true;
        }

        if (_eType._AttackDistance < _enemyMove._dis)
        {
            _enemyMove._isStop = false;
            _enemyMove._speed = _saveSpeed;
        }
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
            _enemyMove._isStop = true;
            //애니메이션 하고~
            //playerHp 깎기

            Damage();

            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator Range()
    {
        while (true)
        {
            _enemyMove._isStop = true;
            //애니메이션 하고~
            //playerHp 깎기, 총알 발사

            InstBullet();

            if (_bulletPrefabs._isCol)
            {
                Damage();
            }

            yield return new WaitForSeconds(3f);
        }
    }

    IEnumerator Magic()
    {
        while (true)
        {
            _enemyMove._isStop = true;
            //애니메이션 하고~
            //playerHp 깎기

            InstBullet();

            if (_bulletPrefabs._isCol)
            {
                Damage();
            }

            yield return new WaitForSeconds(3f);
        }
    }

    private void Damage()
    {
        float damage = _enemy._eType._AttackDamage;

        if (_enemyMove._col.CompareTag("Player"))
            GameManager.instance._player._hp -= damage;
        else
        {
            print(_enemyMove._col.name);
            _enemyMove._col.GetComponent<OurTeam>().DecHp(damage);
        }
    }

    private void InstBullet()
    {
        Bullet b = PoolManager.Instance.Pop("Bullet") as Bullet;

        print(b);
        b.transform.position = transform.position;

        Vector3 dir = _enemyMove._col.transform.position - b.transform.position;
        dir.y = transform.position.y + 1;

        b.GetComponent<Rigidbody>().velocity = dir.normalized * 10;
    }
}

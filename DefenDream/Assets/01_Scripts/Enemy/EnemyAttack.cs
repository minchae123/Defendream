using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyEnum;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Bullet _bulletPrefabs;

    private EnemyMovement _enemyMove;
    private EnemyTypeSO _eType = null;

    private float _saveSpeed;
    private bool _isAtt = false;

    private void Awake()
    {
        _enemyMove = transform.GetComponent<EnemyMovement>();
    }

    private void Start()
    {
        _eType = _enemy._eType;
        _saveSpeed = _enemyMove._speed;
    }

    private void Update()
    {
        Distance();

        if (_enemyMove._target == null || !_enemyMove._target.activeSelf) StopAllCoroutines();
    }

    private void Distance()
    {
        float attDis = _eType._AttackDistance;
        if (_enemyMove._target != null && _enemyMove._target.CompareTag("Player"))
            attDis += 3f;

        print(attDis);

        if (attDis >= _enemyMove._dis && !_isAtt)
        {
            _enemyMove._isStop = true;
            _enemyMove._speed = 0;

            Att();

            _isAtt = true;
        }

        else if (attDis < _enemyMove._dis)
        {
            _enemyMove._speed = _saveSpeed;
            _enemyMove._isStop = false;

            _isAtt = false;
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
            Damage();

            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator Range()
    {
        while (true)
        {
            InstBullet();

            yield return new WaitForSeconds(3f);
        }
    }

    IEnumerator Magic()
    {
        while (true)
        {
            InstBullet();

            SoundManager.Instance.Magic();
            yield return new WaitForSeconds(3f);
        }
    }

    private void Damage()
    {
        if (_enemyMove._target == null || !_enemyMove._target.activeSelf)
        {
            _enemyMove._speed = _saveSpeed;
            return;
        }

        float damage = _enemy._eType._AttackDamage;

        Fighting fight = PoolManager.Instance.Pop("FightParticle") as Fighting;
        fight.transform.position = transform.position + transform.forward * 2;

        if (_enemyMove._target.CompareTag("Player"))
            WeekManager.Instance.StressUp();
        else
            _enemyMove._target.GetComponent<OurTeam>().DecHp(damage);
    }

    private void InstBullet()
    {
        if (_enemyMove._target == null || !_enemyMove._target.activeSelf)
        {
            _enemyMove._speed = _saveSpeed;
            return;
        }

        Bullet b = PoolManager.Instance.Pop("Bullet") as Bullet;

        b._damage = _enemy._eType._AttackDamage;

        b.transform.position = transform.position;

        Vector3 dir = _enemyMove._target.transform.position - b.transform.position;
        dir.y = transform.position.y + 1;

        b.GetComponent<Rigidbody>().velocity = dir.normalized * 10;
    }
}

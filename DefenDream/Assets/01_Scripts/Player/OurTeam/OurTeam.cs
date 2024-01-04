using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using playerType;

public class OurTeam : PoolableMono
{
    public PlayerTypeSO _playerSO;

    [SerializeField] private OurTeamMove _move;
    [SerializeField] private PlayerAnim _pAnim;

    [Header("Bullet")]
    [SerializeField] private PlayerBullet _magicBullet;
    [SerializeField] private PlayerBullet _ArcherBullet;
    [SerializeField] private Transform _FirePos;
    [SerializeField] private float _bulletSpeed;

    private EntityHP hpbar;

    private float _saveSpeed;

    [SerializeField] private float _hp;

    public override void Init()
    {
        _hp = _playerSO._Hp;
        _saveSpeed = _move._speed;
        hpbar.SetHP(_hp);
    }

    private void Awake()
    {
        hpbar = GetComponent<EntityHP>();
        _hp = _playerSO._Hp;
        _saveSpeed = _move._speed;
        hpbar.SetHP(_hp);
    }

    void Update()
    {
        MoveAnim();
    }

    private void MoveAnim()
    {
        bool isWalk = _move._min > _playerSO._AttackDistance;
        _pAnim.WalkAnim(isWalk);

        if (isWalk) _move._speed = _saveSpeed;
        else _move._speed = 0;
    }

    private void Melee()
    {
        _move._nealEnemy.DecHp(_playerSO._AttackDamage);

        Fighting fight = PoolManager.Instance.Pop("FightParticle") as Fighting;
        fight.transform.position = transform.position + transform.forward * 2;
    }

    private void Tanker()
    {
        //¹æ¾î effect¸¸
    }

    private void Magic()
    {
        PlayerBullet bullet = Instantiate(_magicBullet, transform);
        bullet.transform.position = _FirePos.position;

        bullet.GetComponent<Rigidbody>().velocity = _move._direction.normalized * _bulletSpeed;
    }

    private void Archer()
    {
        PlayerBullet bullet = Instantiate(_ArcherBullet, transform);
        bullet.transform.position = _FirePos.position;

        bullet.GetComponent<Rigidbody>().velocity = _move._direction.normalized * _bulletSpeed;
    }

    public void DecHp(float damage)
    {
        _hp -= damage;
        hpbar.OnDamage(damage);
        DieAnim();

        print(_hp);
    }

    private void DieAnim()
    {
        if (_hp <= 0)
        {
            _pAnim.DieAnim();

            Invoke("DestroyObj", 1);
        }
    }

    private void DestroyObj()
    {
        PoolManager.Instance.Push(this);
    }
}

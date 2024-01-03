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

    private float _saveSpeed;

    [SerializeField] private float _hp;


    public override void Init()
    {
        _hp = _playerSO._Hp;
        _saveSpeed = _move._speed;
    }

    void Update()
    {
        MoveAnim();
    }

    private void MoveAnim()
    {
        bool isWalk = _move._min > _playerSO._AttackDistance;

        _pAnim.WalkAnim(isWalk);

        if(isWalk) _move._speed = _saveSpeed;
        else _move._speed = 0;
    }

    private void Melee()
    {
        _move._nealEnemy.DecHp(_playerSO._AttackDamage);
    }

    private void Tanker()
    {
        //¹æ¾î effect¸¸
    }
                
    private void Magic()
    {
        PlayerBullet bullet = PoolManager.Instance.Pop("MagicBullet") as PlayerBullet;
        bullet.transform.position = _FirePos.position;

        bullet.GetComponent<Rigidbody>().velocity = _move._direction.normalized * _bulletSpeed;
    }

    private void Archer()
    {
        PlayerBullet bullet = PoolManager.Instance.Pop("ArcherBullet") as PlayerBullet;
        bullet.transform.position = _FirePos.position;

        bullet.GetComponent<Rigidbody>().velocity = _move._direction.normalized * _bulletSpeed;
    }

    public void DecHp(float damage)
    {
        _hp -= damage;
    }
}

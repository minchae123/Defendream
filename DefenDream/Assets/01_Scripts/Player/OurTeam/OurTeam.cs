using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using playerType;

public class OurTeam : PoolableMono
{
    public PlayerTypeSO _playerSO;

    private OurTeamMove _move;
    private PlayerAnim _pAnim;

    [Header("Bullet")]
    [SerializeField] private Transform _FirePos;
    [SerializeField] private float _bulletSpeed;

    private EntityHP hpbar;

    private float _saveSpeed;

    [SerializeField] private float _hp;

    public override void Init()
    {
        _hp = _playerSO._Hp;
        hpbar.SetHP(_hp);
        hpbar.ResetHP();
    }

    private void Awake()
    {
        hpbar = GetComponent<EntityHP>();
        _move = GetComponent<OurTeamMove>();
        _pAnim = GetComponent<PlayerAnim>();

        _hp = _playerSO._Hp;
        _saveSpeed = _move._speed;
        hpbar.SetHP(_hp);
    }

    void Update()
    {
        MoveAnim();
        DieAnim();
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
        //방어 effect만
    }

    private void Magic()
    {
        MagicBullet bullet = PoolManager.Instance.Pop("Magic") as MagicBullet;
        bullet.transform.position = _FirePos.position;
        bullet.Damage(_playerSO._AttackDamage);

        Vector3 dir = _move._direction.normalized;
        dir.y = 0;

        bullet.GetComponent<Rigidbody>().velocity = dir * _bulletSpeed;
    }

    private void Archer()
    {
        ArcherBullet ArcherBullet = PoolManager.Instance.Pop("Arrow") as ArcherBullet;
        ArcherBullet.transform.position = _FirePos.position;
        ArcherBullet.Damage(_playerSO._AttackDamage);

        // 방향 설정
        Vector3 bulletDirection = _move._direction.normalized;
        ArcherBullet.GetComponent<Rigidbody>().velocity = bulletDirection * _bulletSpeed;

        // 회전 설정
        if (bulletDirection != Vector3.zero)
        {
            Quaternion bulletRotation = Quaternion.LookRotation(bulletDirection, Vector3.up);
            bulletRotation *= Quaternion.Euler(90f, 0f, 0f);
            ArcherBullet.GetComponent<Rigidbody>().rotation = bulletRotation;
        }
    }

    public void DecHp(float damage)
    {
        _hp -= damage;
        // 사잇값으로
        _hp = Mathf.Clamp(_hp, 0, _playerSO._Hp);
        hpbar.OnDamage(damage);
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

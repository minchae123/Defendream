using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using playerType;

public class OurTeam : MonoBehaviour
{
    public PlayerTypeSO _playerSO;

    [SerializeField] private OurTeamMove _move;
    [SerializeField] private PlayerAnim _pAnim;

    [Header("Bullet")]
    [SerializeField] private GameObject _magicBullet;
    [SerializeField] private GameObject _ArcherBullet;
    [SerializeField] private Transform _FirePos;
    [SerializeField] private float _bulletSpeed;

    private float _saveSpeed;

    [SerializeField] private float _hp;

    // Start is called before the first frame update
    void Start()
    {
        _hp = _playerSO._Hp;
        _saveSpeed = _move._speed;
    }

    // Update is called once per frame
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
        GameObject obj = Instantiate(_magicBullet, transform);
        obj.transform.position = _FirePos.position;

        obj.GetComponent<Rigidbody>().velocity = _move._direction.normalized * _bulletSpeed;
    }

    private void Archer()
    {
        GameObject obj = Instantiate(_ArcherBullet, transform);
        obj.transform.position = _FirePos.position;

        obj.GetComponent<Rigidbody>().velocity = _move._direction.normalized * _bulletSpeed;
    }

    public void DecHp(float damage)
    {
        _hp -= damage;
    }
}

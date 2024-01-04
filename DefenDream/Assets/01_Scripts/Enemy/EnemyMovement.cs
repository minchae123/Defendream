using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody _rb;

    [HideInInspector] public GameObject _target = null;
    [HideInInspector] public Vector3 _bulletDir;
    [HideInInspector] public float _dis = float.MaxValue;

    public bool _isStop = false;
    public float _speed;

    private float _playerDis;
    private Vector3 _playerDir;
    private Vector3 _WarriorDir;

    private List<GameObject> _exceptObj = new List<GameObject>();

    Vector3 boxSize = new Vector3(100f, 100f, 100f);

    private EnemyAttack _enemyAttack;
    public Action freeze;

    private void Awake()
    {
        _dis = float.MaxValue;
        _rb = GetComponent<Rigidbody>();

        _playerDis = Vector3.Distance(transform.position, GameManager.instance._playerTrm.position);

        _enemyAttack = GetComponent<EnemyAttack>();
        freeze += Freeze;
    }

    void Update()
    {
        if (!_isStop)
            Move();

        OverlapBox();
    }

    private void Move()
    {
        _playerDir = GameManager.instance._playerTrm.position - transform.position;
        _playerDis = Vector3.Distance(GameManager.instance._playerTrm.position, transform.position);

        _rb.velocity = _WarriorDir.normalized * _speed;

        _bulletDir = _rb.velocity;

        if (_WarriorDir != Vector3.zero)
        {
            Quaternion warriorRotation = Quaternion.LookRotation(new Vector3(_WarriorDir.x, 0f, _WarriorDir.z), Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, warriorRotation, Time.deltaTime * 5f);
        }
    }

    private void OverlapBox()
    {
        Collider[] colliders;

        colliders = Physics.OverlapBox(transform.position, boxSize);
        foreach (var item in colliders)
        {
            if (GameManager.instance._focusTarget[item.gameObject] == 2) continue;
            if (!item.CompareTag("Team") && !item.CompareTag("Player")) continue;

            float dis = Vector3.Distance(item.transform.position, transform.position);

            if (_dis > dis)
            {
                _dis = dis;
                _target = item.gameObject;

                int i = GameManager.instance._focusTarget[_target]++;

                //if (i == 2)
                //    _exceptObj = new List<GameObject>(GameManager.instance._focusTarget.Keys);

                _WarriorDir = item.transform.position - transform.position;
                _WarriorDir.y = transform.position.y;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }

    public void Freeze() => StartCoroutine(UnFreeze());

    private IEnumerator UnFreeze()
    {
        _enemyAttack.enabled = false;
        _rb.velocity = Vector3.zero;
        _isStop = true;
        yield return new WaitForSeconds(4.5f);
        _isStop = false;
        _enemyAttack.enabled = true;
    }
}
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

    private bool _isMoveStop = false;
    private Vector3 _WarriorDir;

    Vector3 boxSize = new Vector3(100f, 100f, 100f);

    private EnemyAttack _enemyAttack;
    public Action freeze;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _enemyAttack = GetComponent<EnemyAttack>();

        freeze += Freeze;
    }

    private void Start()
    {
    }

    void Update()
    {
        if (!_isMoveStop)
            Move();

        if (!_isStop)
        {
            OverlapBox();
            Focusing();
        }

        if (_target == null || !_target.activeSelf)
        {
            _isStop = false;

            _target = GameManager.instance._player.gameObject;

            _WarriorDir = _target.transform.position - transform.position;
            _WarriorDir.y = transform.position.y;

            float dis = Vector3.Distance(_target.transform.position, transform.position);

            _dis = dis;
        }

        //if(_target != null && !_target.activeSelf)
        //{
        //    _target = null;
        //    _isStop = false;
        //    _dis = float.MaxValue;
        //}
    }

    private void Move()
    {
        if (_target != null && (_target.activeSelf == true))
        {
            _WarriorDir = _target.transform.position - transform.position;
            _WarriorDir.y = transform.position.y;

            _dis = Vector3.Distance(_target.transform.position, transform.position);
        }
        _rb.velocity = _WarriorDir.normalized * _speed;

        _bulletDir = _rb.velocity;

        RotDir();
    }

    private void RotDir()
    {
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
            if (GameManager.instance._focusTarget.ContainsKey(item.gameObject))
                if (GameManager.instance._focusTarget[item.gameObject] >= 3) continue;

            if (!item.CompareTag("Team") && !item.CompareTag("Player")) continue;

            float dis = Vector3.Distance(item.transform.position, transform.position);

            if (_dis > dis)
            {
                _dis = dis;
                _target = item.gameObject;
            }
        }
    }

    public void Focusing()
    {
        //Æ÷Ä¿½Ì
        if (GameManager.instance._focusTarget.ContainsKey(_target))
            GameManager.instance._focusTarget[_target]++;
        else
        {
            GameManager.instance._focusTarget.Add(_target, 1);
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
        _isMoveStop = true;
        yield return new WaitForSeconds(4.5f);
        _isMoveStop = false;
        _enemyAttack.enabled = true;
    }
}
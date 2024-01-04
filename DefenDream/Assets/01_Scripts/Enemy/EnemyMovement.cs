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

    public Action freeze;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

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
            OverlapBox();

        if (_target == null || !_target.activeSelf)
        {
            _isStop = false;

            _target = GameManager.instance._playerTrm.gameObject;

            _WarriorDir = GameManager.instance._playerTrm.gameObject.transform.position - transform.position;
            _WarriorDir.y = 0;

            float dis = Vector3.Distance(GameManager.instance._playerTrm.gameObject.transform.position, transform.position);

            _dis = dis;
        }
    }

    private void Move()
    {
        if (_target != null && (_target.activeSelf == true))
        {
            _WarriorDir = _target.transform.position - transform.position;
            _WarriorDir.y = 0;

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
            if (!item.CompareTag("Team") && !item.CompareTag("Player")) continue;

            float dis = Vector3.Distance(item.transform.position, transform.position);

            if (_dis > dis)
            {
                _dis = dis;
                _target = item.gameObject;
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
        _rb.velocity = Vector3.zero;
        _isMoveStop = true;
        yield return new WaitForSeconds(4.5f);
        _isMoveStop = false;
    }
}
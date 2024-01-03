using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolableMono
{
    public bool _isCol = false;

    [HideInInspector] public Rigidbody _rb;

    [SerializeField] private float _speed;
    [SerializeField] private CapsuleCollider[] _col;

    OurTeam _team;

    public override void Init()
    {

    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Invoke("DestroyObj", 5);
    }

    private void OnTriggerEnter(Collider collider)
    {
        foreach (var item in _col)
        {
            if (collider == item)
                DestroyObj();
        }

        if (collider.TryGetComponent<OurTeam>(out OurTeam team))
        {
            _isCol = true;
            _team = team;
        }

        if (collider.CompareTag("Player"))
        {
            _isCol = true;
            DestroyObj();
        }
    }

    private void DestroyObj()
    {
        Destroy(gameObject);
        //PoolManager.Instance.Push(this);
    }

    public void DecHp(float damage)
    {
        _team.DecHp(damage);
    }
}

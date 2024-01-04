using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolableMono
{
    [HideInInspector] public Rigidbody _rb;
    [HideInInspector] public float _damage;

    [SerializeField] private float _speed;
    [SerializeField] private Collider[] _col;

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
        foreach (Collider item in _col)
        {
            if (collider.GetComponent<CapsuleCollider>() == item)
            {
                print(item);
                DestroyObj();
            }
        }

        if (collider.CompareTag("Col"))
        {
            OurTeam team = collider.GetComponentInParent<OurTeam>();
            team.DecHp(_damage);
            DestroyObj();
        }

        if (collider.CompareTag("Player"))
        {
            WeekManager.Instance.StressUp();
            DestroyObj();
        }
    }

    private void DestroyObj()
    {
        Destroy(gameObject);
        //PoolManager.Instance.Push(this);
    }
}

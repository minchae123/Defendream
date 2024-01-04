using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolableMono
{
    [HideInInspector] public Rigidbody _rb;
    [HideInInspector] public float _damage;

    [SerializeField] private float _speed;

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
        if (collider.CompareTag("Col"))
        {
            OurTeam team = collider.GetComponentInParent<OurTeam>();
            ShotParticle shotParticle = PoolManager.Instance.Pop("ShotParticle") as ShotParticle;
            shotParticle.transform.position = transform.position;
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
        PoolManager.Instance.Push(this);
    }
}

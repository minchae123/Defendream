using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherBullet : PoolableMono
{
    private float _damage;

    public override void Init()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Invoke("DestroyObj", 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Team") || other.CompareTag("Col")) return;

        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            ShotParticle shotParticle = PoolManager.Instance.Pop("ShotParticle") as ShotParticle;
            shotParticle.transform.position = transform.position;
            enemy.DecHp(_damage);
        }

        DestroyObj();
    }

    private void DestroyObj()
    {
        PoolManager.Instance.Push(this);
    }

    public void Damage(float damage)
    {
        _damage = damage;
    }
}

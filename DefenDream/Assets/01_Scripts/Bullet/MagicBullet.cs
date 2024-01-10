using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBullet : PoolableMono
{
    private float _damage;

    public override void Init() { }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Team") || other.CompareTag("Col")) return;

        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            ShotParticle shotParticle = PoolManager.Instance.Pop("ShotParticle") as ShotParticle;
            shotParticle.transform.position = transform.position;
            enemy.DecHp(_damage);
        }

        if (other.CompareTag("Wall"))
        {
            print("»ç¶óÁü");
            DestroyObj();
        }
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

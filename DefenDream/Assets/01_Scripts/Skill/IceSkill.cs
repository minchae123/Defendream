using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSkill : PoolableMono
{
    private BoxCollider _col;

    public override void Init()
    {
        _col.enabled = true;
    }

    private void OnEnable()
    {
        StartCoroutine(WaitPool());
    }

    private IEnumerator WaitPool()
    {
        yield return new WaitForSeconds(0.25f);
        _col.enabled = false;
        yield return new WaitForSeconds(4.75f);
        PoolManager.Instance.Push(this);
    }

    void Awake()
    {
        _col = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyMovement>().freeze();
        }
    }
}

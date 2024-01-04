using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : PoolableMono
{
    [SerializeField] private float DMG;

    public override void Init()
    {
    }

    private void OnEnable()
    {
        StartCoroutine(WaitPool());
    }

    private IEnumerator WaitPool()
    {
        yield return new WaitForSeconds(2f);
        PoolManager.Instance.Push(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().DecHp(DMG);
        }
    }
}

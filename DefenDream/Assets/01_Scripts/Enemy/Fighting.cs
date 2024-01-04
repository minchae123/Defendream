using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : PoolableMono
{
    public override void Init()
    {
    }

    private void OnEnable()
    {
        StartCoroutine(WaitPool());
    }

    private IEnumerator WaitPool()
    {
        yield return new WaitForSeconds(1f);
        PoolManager.Instance.Push(this);
    }
}

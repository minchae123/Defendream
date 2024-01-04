using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotParticle : PoolableMono
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
        yield return new WaitForSeconds(.25f);
        PoolManager.Instance.Push(this);
    }
}

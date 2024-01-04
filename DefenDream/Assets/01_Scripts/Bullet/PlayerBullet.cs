using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : PoolableMono
{
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
        if (other.CompareTag("Team")) return;

        DestroyObj();
    }

    private void DestroyObj()
    {
        PoolManager.Instance.Push(this);
    }
}

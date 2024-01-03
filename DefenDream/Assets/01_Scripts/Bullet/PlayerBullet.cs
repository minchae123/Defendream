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
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Team")) return;

        print(other.name);
        Destroy(gameObject);
        PoolManager.Instance.Push(this);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoSkill : PoolableMono
{
    [SerializeField] private float _duration;

    public override void Init()
    {
    }

    private void OnEnable()
    {
        StartCoroutine(WaitPool());
    }

    private IEnumerator WaitPool()
    {
        yield return new WaitForSeconds(_duration);
        PoolManager.Instance.Push(this);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(-90, 0, transform.rotation.z);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce((transform.position - other.transform.position).normalized, ForceMode.Impulse);
        }
    }
}

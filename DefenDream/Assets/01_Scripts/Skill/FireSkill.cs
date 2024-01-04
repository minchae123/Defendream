using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkill : PoolableMono
{
    private Rigidbody _rb;

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
        yield return new WaitForSeconds(1.5f);
        PoolManager.Instance.Push(this);
    }

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _rb.AddForce(new Vector3(4,0,0), ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().DecHp(DMG);
        }
    }
}

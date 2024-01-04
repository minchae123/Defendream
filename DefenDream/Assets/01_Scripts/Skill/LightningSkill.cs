using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSkill : PoolableMono
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
        SoundManager.Instance.Lightning();
        yield return new WaitForSeconds(1f);
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

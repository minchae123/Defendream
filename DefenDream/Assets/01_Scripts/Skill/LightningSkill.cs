using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSkill : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().DecHp(5);
        }
    }
}

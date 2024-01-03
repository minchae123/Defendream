using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSkill : MonoBehaviour
{
    private BoxCollider _col;

    void Start()
    {
        _col = GetComponent<BoxCollider>();

        Destroy(gameObject,5);
        Destroy(_col, .25f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyMovement>().freeze();
            Debug.Log("freeze");
        }
    }
}

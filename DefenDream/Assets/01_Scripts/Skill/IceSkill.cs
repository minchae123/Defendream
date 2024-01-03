using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSkill : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject,5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Rigidbody>();
            Debug.Log("freeze");
        }
    }
}

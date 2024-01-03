using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkill : MonoBehaviour
{
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 3);
    }

    void Update()
    {
        _rb.AddForce(new Vector3(4,0,0), ForceMode.Impulse);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Enemy"))
    //    {
    //        Debug.Log("Hurt");
    //    }
    //}
}

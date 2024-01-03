using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoSkill : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2.75f);
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

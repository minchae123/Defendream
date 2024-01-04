using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Coin : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.AddForce(new Vector3(0, 10   , 0), ForceMode.Impulse);
        Invoke(nameof(DestroyObj), 1.5f);
    }
    private void Update()
    {
        transform.Rotate(new Vector3(0, 10f, 0));
    }

    private void DestroyObj()
    {
        Destroy(gameObject);
    }
}

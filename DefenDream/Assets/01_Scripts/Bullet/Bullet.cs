using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] private float _speed;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = GameManager.instance._playerTrm.position - transform.position;
        _rb.velocity = dir.normalized * _speed;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

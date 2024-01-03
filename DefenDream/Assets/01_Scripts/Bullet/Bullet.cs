using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool _isCol = false;

    [SerializeField] private float _speed;

    [HideInInspector] public Rigidbody _rb;
    OurTeam _team;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Invoke("DestroyObj", 10);
    }

    private void OnTriggerEnter(Collider collider)
    {
        //if(collider.CompareTag("Player") || collider.CompareTag("Team"))
        //    DestroyObj();

        if (collider.TryGetComponent<OurTeam>(out OurTeam team))
        {
            _isCol = true;
            _team = team;
        }

        if (collider.CompareTag("Player"))
        {
            _isCol = true;
        }
    }

    private void DestroyObj()
    {
        Destroy(gameObject);
    }

    public void DecHp(float damage)
    {
        _team.DecHp(damage);
    }
}

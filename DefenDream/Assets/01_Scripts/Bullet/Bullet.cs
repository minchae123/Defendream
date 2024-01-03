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

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Enemy"))
            Destroy(gameObject);

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

    public void DecHp(float damage)
    {
        _team.DecHp(damage);
    }
}

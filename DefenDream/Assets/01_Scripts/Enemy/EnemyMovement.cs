using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float _speed;

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 dir = GameManager.instance._player.position - transform.position;

        _rb.velocity = dir.normalized * _speed;
    }
}

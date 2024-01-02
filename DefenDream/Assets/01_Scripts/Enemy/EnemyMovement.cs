using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody _rb;

    public float _speed;

    private float _playerDis;
    private Vector3 _playerDir;
    private Vector3 _WarriorDir;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        _playerDis = Vector3.Distance(transform.position, GameManager.instance._playerTrm.position);
    }

    void Update()
    {
        Move();
        OverlapBox();
    }

    private void Move()
    {
        _playerDir = GameManager.instance._playerTrm.position - transform.position;
        _playerDis = Vector3.Distance(GameManager.instance._playerTrm.position, transform.position);
    }

    private void OverlapBox()
    {
        Vector3 boxSize = new Vector3(2f, 2f, 2f);
        Collider[] colliders;
        float saveDis = int.MaxValue;

        colliders = Physics.OverlapBox(transform.position, boxSize / 2f);

        foreach (var item in colliders)
        {
            if (item.gameObject.CompareTag("Warrior")) continue;

            float dis = Vector3.Distance(item.transform.position, transform.position);

            if(_playerDis > dis)
            {
                saveDis = dis;
                _WarriorDir = item.transform.position - transform.position;
            }
        }

        _rb.velocity = (saveDis < _playerDis ? _playerDir: _WarriorDir).normalized * _speed;
    }
}

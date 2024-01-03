using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody _rb;

    [HideInInspector] public GameObject _col = null;
    [HideInInspector] public Vector3 _bulletDir;
    [HideInInspector] public float _dis = float.MaxValue;

    public bool _isStop = false;
    public float _speed;

    private float _playerDis;
    private Vector3 _playerDir;
    private Vector3 _WarriorDir;

    Vector3 boxSize = new Vector3(10f, 10f, 10f);

    private void Awake()
    {
        _dis = float.MaxValue;
        _rb = GetComponent<Rigidbody>();

        _playerDis = Vector3.Distance(transform.position, GameManager.instance._playerTrm.position);
    }

    void Update()
    {
        Move();

        if (!_isStop)
        OverlapBox();
    }

    private void Move()
    {
        _playerDir = GameManager.instance._playerTrm.position - transform.position;
        _playerDis = Vector3.Distance(GameManager.instance._playerTrm.position, transform.position);

        _rb.velocity = _WarriorDir.normalized * _speed;

        _bulletDir = _rb.velocity;
    }

    private void OverlapBox()
    {
        Collider[] colliders;

        colliders = Physics.OverlapBox(transform.position, boxSize / 2f);
        foreach (var item in colliders)
        {
            if (!item.CompareTag("Team") && !item.CompareTag("Player")) continue;

            float dis = Vector3.Distance(item.transform.position, transform.position);

            if (_dis > dis)
            {
                _dis = dis;
                _col = item.gameObject;

                _WarriorDir = item.transform.position - transform.position;
                _WarriorDir.y = transform.position.y;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }
}
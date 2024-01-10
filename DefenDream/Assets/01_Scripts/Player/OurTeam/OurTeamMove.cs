using System.Collections.Generic;
using UnityEngine;

public class OurTeamMove : MonoBehaviour
{
    public float _speed;

    public List<Enemy> _enemyList = new List<Enemy>();

    [HideInInspector] public float _min = float.MaxValue;

    [HideInInspector] public Vector3 _direction;
    [HideInInspector] public Enemy _nealEnemy;

    [SerializeField] private float maxRotationAngle = 10f;
    Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        NealObj();

        _rb.velocity = _direction.normalized * _speed;

        if (_direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(new Vector3(_direction.x, 0f, _direction.z), Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * 5f);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.TryGetComponent<Enemy>(out Enemy enemy))
        {
            GameManager.instance._enemyList.Add(enemy);
        }
    }

    private void NealObj()
    {
        _min = float.MaxValue;

        if (GameManager.instance._enemyList.Count == 0)
            _direction += Vector3.right.normalized * _speed;

        foreach (Enemy obj in GameManager.instance._enemyList)
        {
            if (obj.gameObject.activeSelf == false) continue;

            float dis = Vector3.Distance(transform.position, obj.transform.position);

            if (_min > dis)
            {
                _min = dis;
                _nealEnemy = obj;
                _direction = obj.transform.position - transform.position;
            }
        }
    }
}

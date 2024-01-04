using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolableMono
{
    public bool _isCol = false;

    [HideInInspector] public Rigidbody _rb;

    [SerializeField] private float _speed;
    [SerializeField] private Collider[] _col;

    public override void Init()
    {

    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Invoke("DestroyObj", 5);
    }

    private void OnTriggerEnter(Collider collider)
    {
        foreach (Collider item in _col)
        {
            if (collider.GetComponent<CapsuleCollider>() == item)
            {
                print(item);
                DestroyObj();
            }
        }

        //if (collider.CompareTag("Team") && collider.GetComponent<CapsuleCollider>() != null)
        //{
        //    Debug.Log("Hit");
        //    _isCol = true;
        //    DestroyObj();
        //}
        //else return;


        if (collider.CompareTag("Player"))
        {
            _isCol = true;
            DestroyObj();
        }
    }

    private void DestroyObj()
    {
        Destroy(gameObject);
        //Destroy(this);
        //PoolManager.Instance.Push(this);
    }
}

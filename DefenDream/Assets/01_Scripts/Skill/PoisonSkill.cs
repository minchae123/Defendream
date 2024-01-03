using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonSkill : MonoBehaviour
{
    private float _curTime;

    void Start()
    {
        Destroy(gameObject, 5);
    }
    private void Update()
    {
        if (0 < _curTime)
        {
            _curTime -= Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (_curTime <= 0)
            {
                other.gameObject.GetComponent<Enemy>().DecHp(2);

                _curTime = 1;
            }
        }
    }
}

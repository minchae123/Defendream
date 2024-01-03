using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private float spawnMin = 2, spawnMax = 4;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _parent;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            float rTime = Random.Range(spawnMin, spawnMax);
            yield return new WaitForSeconds(rTime);

            Enemy obj = PoolManager.Instance.Pop("Enemy") as Enemy;

            float posZ = Random.Range(-10f, 5.5f);
            Vector3 pos = new Vector3(transform.position.x, 0, posZ);
            obj.transform.position = pos;
        }
    }
}

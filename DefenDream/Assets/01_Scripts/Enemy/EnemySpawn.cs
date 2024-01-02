using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private float _spawnEnemyTime;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _parent;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnEnemyTime);

            Instantiate(_enemy, _parent);
        }
    }
}

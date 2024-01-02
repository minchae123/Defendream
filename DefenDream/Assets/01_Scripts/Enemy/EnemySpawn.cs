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

            GameObject obj = Instantiate(_enemy, _parent);

            int posZ = Random.Range(-15, 15);
            Vector3 pos = new Vector3(transform.position.x, 0, posZ);

            obj.transform.position = pos;
        }
    }
}

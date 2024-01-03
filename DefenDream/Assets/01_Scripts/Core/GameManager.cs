using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private PoolingSO poolSO;
    public Camera mainCam;

    public Transform _playerTrm;
    public Player _player;

    private void Awake()
    {
        if (instance != null)
            Debug.Log("Error");

        instance = this;
        mainCam = Camera.main;

        MakePool();
    }

    private void MakePool()
    {
        PoolManager.Instance = new PoolManager(transform);
        poolSO.poolingList.ForEach(p => PoolManager.Instance.CreatePool(p.prefab, p.poolCount));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void GoBack()
	{
        SettingUI.Instance.Off();
	}

    public void GoStart()
	{
        SceneManager.LoadScene(0);
	}

    public void GoReStarT()
	{
        SceneManager.LoadScene(1);
	}
		
}

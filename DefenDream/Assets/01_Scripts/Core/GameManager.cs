using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform _playerTrm;
    public Player _player;
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
            Debug.Log("Error");

        instance = this;
    }
}

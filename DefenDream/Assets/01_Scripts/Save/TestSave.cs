using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSave : MonoBehaviour
{
	public GameData data;

	private SaveSystem saveSystem;

	public int coin;

	public int card1;
	public int card2;
	public int card3;
	public int card4;
	public int card5;
	public int card6;

	public GameData dataa;

	private void Awake()
	{
		saveSystem = FindObjectOfType<SaveSystem>();
	}

	private void Start()
	{
		LoadData();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			SaveData();
		}

		if (Input.GetKeyDown(KeyCode.J))
		{
			LoadData();
		}
	}

	public void SaveData()
	{
		data.gold = coin;

		saveSystem.Save(data);
	}

	public void LoadData()
	{
		data = saveSystem.Load();
	}
}

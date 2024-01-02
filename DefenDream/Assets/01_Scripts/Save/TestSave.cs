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

	private void Awake()
	{
		saveSystem = FindObjectOfType<SaveSystem>();
	}

	private void Start()
	{
		data = saveSystem.Load();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			SaveData();
		}

		if (Input.GetKeyDown(KeyCode.J))
		{

		}
	}

	public void SaveData()
	{
		data.gold = coin;
		data.card1 = card1;
		data.card2 = card2;
		data.card3 = card3;
		data.card4 = card4;
		data.card5 = card5;

		saveSystem.Save(data);
	}

	public void LoadData()
	{
		data = saveSystem.Load();
	}
}

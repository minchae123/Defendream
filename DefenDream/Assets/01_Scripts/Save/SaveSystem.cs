using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
	 public GameData gameData;

	private string savePath;
	private string fileName = "/GameData.txt";

	private void Awake()
	{
		gameData = new GameData();
		savePath = Application.dataPath + "/SaveData/";


		if(!Directory.Exists(savePath))
		{
			Directory.CreateDirectory(savePath);
		}
	}

	[ContextMenu("Save")]
	public void Save(GameData data)
	{
		gameData = data;

		string json = JsonUtility.ToJson(gameData);
		File.WriteAllText(savePath + fileName, json);

	}

	[ContextMenu("Load")]
	public GameData Load()
	{
		if (File.Exists(savePath + fileName))
		{
			string loadJson = File.ReadAllText(savePath + fileName);
			gameData = JsonUtility.FromJson<GameData>(loadJson);

			return gameData;
		}

		else
		{
			Debug.Log("Save Failed");
			return null;
		}
	}

	public void ResetData()
	{
		gameData.gold = 0;
		//gameData.cards.Clear();

		Save(gameData);
	}

	public void ReGame()
	{
		gameData.gold = 100000000;
		for (int i = 0; i < 10; i++)
		{
			gameData.cards[i] = 1000;
		}
		
		Save(gameData);
	}
}

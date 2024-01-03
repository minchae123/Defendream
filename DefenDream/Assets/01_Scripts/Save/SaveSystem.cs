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

		print("저장");
	}

	[ContextMenu("Load")]
	public GameData Load()
	{
		if (File.Exists(savePath + fileName))
		{
			string loadJson = File.ReadAllText(savePath + fileName);
			gameData = JsonUtility.FromJson<GameData>(loadJson);

			print("로드");
			return gameData;
		}

		else
		{
			Debug.Log("Save Failed");
			return null;
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    private SaveSystem save;
    private GameData data;

    public Dictionary<CardSO, int> cardInventory; // 카드가 몇 개 있는가? 가지고 있는 딕셔너리

    private List<string> cardNames;

    List<KeyValuePair<CardSO, int>> lists = new List<KeyValuePair<CardSO, int>>();
    
    private void Awake()
    {
        if (Instance != null) print("inventory Error");
        Instance = this;
        cardInventory = new Dictionary<CardSO, int>();

    }

    private void Start()
    {
        save = FindObjectOfType<SaveSystem>();
        LoadData();
    }

	public void InventoryIndex()
	{
        lists = cardInventory.OrderBy(kvp => kvp.Key).ToList();
    }

    public void SetInventory(MercenaryInfo infos, int numbers)
    {
        cardInventory.Add(infos.card, numbers);
        //print($"{infos.MercenaryName}, {infos.card}, {numbers}");
    }

    public void UseInventory(CardSO currentCard)
    {
        --cardInventory[currentCard]; // 사용
        int index = lists.FindIndex(kvp => kvp.Key == currentCard);
        print(index);
        SaveData(index, cardInventory[currentCard]);
        // N번째 카드 데이터 삭제 -> data.cards[n]--; <- 이렇게 대충 해주면 될듯?
        //print($"{currentCard}: {cardInventory[currentCard]}개");
    }

    public void SaveData(int currentCard, int num)
	{
		data.cards[currentCard] = num;
    }

    public void LoadData()
	{
        data = save.Load();
    }
}

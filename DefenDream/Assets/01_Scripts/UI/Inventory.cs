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

    public Dictionary<CardSO, int> cardInventory; // ī�尡 �� �� �ִ°�? ������ �ִ� ��ųʸ�

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
        --cardInventory[currentCard]; // ���
        int index = lists.FindIndex(kvp => kvp.Key == currentCard);
        print(index);
        SaveData(index, cardInventory[currentCard]);
        // N��° ī�� ������ ���� -> data.cards[n]--; <- �̷��� ���� ���ָ� �ɵ�?
        //print($"{currentCard}: {cardInventory[currentCard]}��");
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    private SaveSystem save;
    private GameData data;

    public Dictionary<CardSO, int> cardInventory; // ī�尡 �� �� �ִ°�? ������ �ִ� ��ųʸ�

    private List<string> cardNames;

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
    public void SetInventory(MercenaryInfo infos, int numbers)
    {
        cardInventory.Add(infos.card, numbers);
        //print($"{infos.MercenaryName}, {infos.card}, {numbers}");
    }
    public void UseInventory(CardSO currentCard)
    {
        --cardInventory[currentCard]; // ���
        SaveData(currentCard, cardInventory[currentCard]);
        // N��° ī�� ������ ���� -> data.cards[n]--; <- �̷��� ���� ���ָ� �ɵ�?
        //print($"{currentCard}: {cardInventory[currentCard]}��");
    }

    public void SaveData(CardSO currentCard, int num)
	{
        if (cardInventory.TryGetValue(currentCard, out int cardCount))
        {
			data.cards[cardCount] = num;
        }
    }

    public void LoadData()
	{
        data = save.Load();
    }
}

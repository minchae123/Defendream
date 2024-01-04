using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashManager : MonoSingleton<CashManager>
{
    private int cash;

    private GameData data;
    private SaveSystem save;

	private void Awake()
	{
		save = FindObjectOfType<SaveSystem>();
	}

	private void Start()
    {
        //���̽����� �ҷ� �ñ�䱸��Ʈ
        LoadData();
        cash = data.gold;
    }

    public int Cash
    {
        get { return cash; }
        private set { cash = value; }
    }

    public void EarnMoney(int amount)
    {
        cash += amount;
        //���̽� �̰�����
    }

    // ���� ���� �޼���
    public void SpendMoney(int amount)
    {
        cash -= amount;
        //���̽� �̰�����
    }

    public void LoadData()
	{
        data = save.Load();
	}
}

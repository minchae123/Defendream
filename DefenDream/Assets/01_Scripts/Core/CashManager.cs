using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashManager : MonoSingleton<CashManager>
{
    private int cash;

    private void Start()
    {
        //제이슨으로 불러 올까요구르트
        cash += 1000000;
    }

    public int Cash
    {
        get { return cash; }
        private set { cash = value; }
    }

    public void EarnMoney(int amount)
    {
        cash += amount;
        //제이슨 이것저것
    }

    // 돈을 빼는 메서드
    public void SpendMoney(int amount)
    {
        cash -= amount;
        //제이슨 이것저것
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 달아주면 됩니다
public class EntityHP : MonoBehaviour
{
    // 이걸 받아오기
    private int currentHP = 0;
    private int maxHP = 0;

    private HealthGauge healthBar;

    private void Start()
    {
        // 모든 엔티티에 달아주고 Start에서 SetHP() 호출하기
        healthBar = transform.GetComponent<HealthGauge>(); // 자식에 HealthBar 달려있을 예정
    }

    public void SetHP(int hp)
    {
        currentHP = maxHP = hp;
    }

    public void OnDamage(int damage) // 데미지 받을 때 같이 호출
    {
        currentHP -= damage;
        healthBar.DamageCheck(damage / maxHP);
        if(currentHP<=0) { print("Die"); }
    }
}

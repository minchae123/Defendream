using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 달아주면 됩니다
public class EntityHP : MonoBehaviour
{
    // 이걸 받아오기
    private float currentHP = 0;
    private float maxHP = 0;

    public HealthGauge HealthBar;

    private void Awake()
    {
        // 모든 엔티티에 달아주고 Start에서 SetHP() 호출하기
        HealthBar = transform.GetComponentInChildren<HealthGauge>(); // 자식에 HealthBar 달려있을 예정
    }

    public void SetHP(float hp)
    {
        currentHP = maxHP = hp;
    }

    public void OnDamage(float damage) // 데미지 받을 때 같이 호출
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        HealthBar.DamageCheck(damage / maxHP);
        //if(currentHP<=0) { print("Die"); }
    }

    public void ResetHP()
	{
        HealthBar.ResetHealth();
	}
}

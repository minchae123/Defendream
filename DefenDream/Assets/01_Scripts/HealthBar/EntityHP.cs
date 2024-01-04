using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �޾��ָ� �˴ϴ�
public class EntityHP : MonoBehaviour
{
    // �̰� �޾ƿ���
    private float currentHP = 0;
    private float maxHP = 0;

    private HealthGauge healthBar;

    private void Awake()
    {
        // ��� ��ƼƼ�� �޾��ְ� Start���� SetHP() ȣ���ϱ�
        healthBar = transform.GetComponentInChildren<HealthGauge>(); // �ڽĿ� HealthBar �޷����� ����
    }

    public void SetHP(float hp)
    {
        currentHP = maxHP = hp;
    }

    public void OnDamage(float damage) // ������ ���� �� ���� ȣ��
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        healthBar.DamageCheck(damage / maxHP);
        //if(currentHP<=0) { print("Die"); }
    }

    public void ResetHP()
	{
        healthBar.ResetHealth();
	}
}

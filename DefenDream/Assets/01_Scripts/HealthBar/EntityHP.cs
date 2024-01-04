using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �޾��ָ� �˴ϴ�
public class EntityHP : MonoBehaviour
{
    // �̰� �޾ƿ���
    private int currentHP = 0;
    private int maxHP = 0;

    private HealthGauge healthBar;

    private void Start()
    {
        // ��� ��ƼƼ�� �޾��ְ� Start���� SetHP() ȣ���ϱ�
        healthBar = transform.GetComponent<HealthGauge>(); // �ڽĿ� HealthBar �޷����� ����
    }

    public void SetHP(int hp)
    {
        currentHP = maxHP = hp;
    }

    public void OnDamage(int damage) // ������ ���� �� ���� ȣ��
    {
        currentHP -= damage;
        healthBar.DamageCheck(damage / maxHP);
        if(currentHP<=0) { print("Die"); }
    }
}

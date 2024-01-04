using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGauge : MonoBehaviour
{
    [SerializeField] private Transform healthBar;
    private float currentScale = 1f;

    private void HealthCheckGauge(float value)
    {
        healthBar.transform.localScale = new Vector3(currentScale - value, 1, 1);
        currentScale -= value;
    }

    public void DamageCheck(float damage)
    {
        HealthCheckGauge(damage);
    }
}

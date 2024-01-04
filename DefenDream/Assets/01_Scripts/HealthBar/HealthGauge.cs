using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGauge : MonoBehaviour
{
    [SerializeField] private Transform healthBar;
    private float currentScale = 1f;

    private void HealthCheckGauge(float value)
    {
        currentScale -= value;
        currentScale = Mathf.Clamp01(currentScale);
        healthBar.transform.localScale = new Vector3(currentScale, 1, 1);
    }

    public void DamageCheck(float damage)
    {
        HealthCheckGauge(damage);
    }

    public void ResetHealth()
	{
        // √ ±‚»≠
        currentScale = 1;
        healthBar.localScale = Vector3.one;
	}
}

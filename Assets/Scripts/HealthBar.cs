using System.Collections;
using System.Collections.Generic;
using Logic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Health health;

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Start is called before the first frame update
    void Start()
    {
        health.onHealthChange += OnHealthChange;
    }

    private void OnHealthChange()
    {
        slider.value = health.currentHealth;
    }
}
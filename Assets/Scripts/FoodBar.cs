using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class FoodBar : MonoBehaviour
{
    public Slider slider;
    
    public float Decreacing = 0.01f ;
    

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    private void Start()
    {
        
    }

    void Update()
    {
        slider.value -=  Decreacing*Time.deltaTime;
        if (slider.value <= 0f)
        {
            slider .value = 0f;
        }
        
        if (slider.value <= 0f)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                Destroy(player);
            }
        }
    }


    

}

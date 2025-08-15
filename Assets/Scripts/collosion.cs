using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collosion : MonoBehaviour
{
    public int maxHealth;
    public int currenthealth;
    public HealthBar healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    // void Update()
    // {
    //     OnCollisionEnter2D();
    // }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            TakeDamage(15);
            Debug.Log("hit");
        }
        
    }

    private void TakeDamage(int damage)
    {
        currenthealth -= damage;
        healthBar.SetHealth(currenthealth);
        
        if (currenthealth == 0)
        {
            Destroy(gameObject);
        }
    }
    
}

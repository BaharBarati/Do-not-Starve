using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class PickupItem : MonoBehaviour
{
    private float pickupRange = 1f;
    public List<Item> inventory = new List<Item>();
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, pickupRange);
            
            foreach (var hitCollider in hitColliders)
            {
                var component = hitCollider.GetComponent<Item>();
                if (component != null)
                {
                    AddToInventory(component);
                    break;
                }
            }
        }
    }

    void AddToInventory(Item item)
    {
        inventory.Add(item);        
        Destroy(item);             
        Debug.Log("Item picked! Inventory count: " + inventory.Count);
    }

}

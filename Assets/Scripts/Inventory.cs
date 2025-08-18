using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using Logic;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private float pickupRange = 1f;
    public List<Item> inventory = new List<Item>();
    private int itemCollectingLimitation = 6;
    public List<Sprite> images = new List<Sprite>();

   public List<Button> slots;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, pickupRange);
            int i = itemCollectingLimitation;
            foreach (var hitCollider in hitColliders)
            {
                var component = hitCollider.GetComponent<Item>();
                if (component != null)
                {
                    if (i > 0 && inventory.Count < 6)
                    {
                        AddToInventory(component);

                        i--;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        // if (Input.GetMouseButtonDown(1))
        // {
        //     // Eating();
        //     int slotToConsume =0;
        //     Eating(slotToConsume);
        // }
    }

    void AddToInventory(Item item)
    {
        inventory.Add(item);
        // image.Add(item.GetComponent<SpriteRenderer>());
        var spriteRenderer = item.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            images.Add(spriteRenderer.sprite);
        }

        UpdateUISlots();

        Destroy(item.gameObject);
        Debug.Log("Item picked!");
    }

    public void Consume(int slotIndex, Health health, int healAmount)
    {
        if (slotIndex < 0 || slotIndex >= images.Count || slotIndex >= inventory.Count)
            return;
        health.Add(healAmount);
        inventory.RemoveAt(slotIndex);
        images.RemoveAt(slotIndex);
    }
    void UpdateUISlots()
    {
        for (int i = 0; i < images.Count; i++)
        {
            if (i < images.Count)
            {
                slots[i].image.sprite = images[i];
                slots[i].image.color = Color.white;
            }
            else
            {
                slots[i].image.sprite = null;
                slots[i].image.color = Color.black;
            }
            
        }
    }
    // void Eating(int slotIndex)
    // {
    //     if (slotIndex < images.Count && slotIndex < inventory.Count)
    //     {
    //         
    //         inventory.RemoveAt(slotIndex);
    //         images.RemoveAt(slotIndex);
    //         
    //         sloths[slotIndex].sprite = null;
    //         sloths[slotIndex].color = new Color(1f, 1f, 1f, 0f);
    //     }
    // }
}
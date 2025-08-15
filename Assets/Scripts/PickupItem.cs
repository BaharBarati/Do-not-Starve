using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PickupItem : MonoBehaviour
{
    private float pickupRange = 1f;
    public List<Item> inventory = new List<Item>();
    public List<UISloth> slots = new List<UISloth>();
    private int itemCollectingLimitation =6;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
                        if (i > 0  && inventory.Count<6)
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
    }

    void AddToInventory(Item item)
    {
        inventory.Add(item);
        // image.Add(item.GetComponent<SpriteRenderer>());
        var spriteRenderer = item.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            foreach (var slot in slots)
            {
                var isEmpty = slot.IsEmpty();
                if (isEmpty)
                {
                    slot.SetImage(spriteRenderer.sprite);
                    break;
                }
            }
        }
        
        Destroy(item.gameObject);
        Debug.Log("Item picked!");
    }
    // void Eating()
    // {
    //     int count = Mathf.Min(sloths.Count, images.Count);
    //     for (int i = 0; i < count; i++)
    //     { 
    //         images[i] = sloths[i].sprite;
    //         sloths[i].color = new Color(0f, 0f, 0f, 0f);;
    //         inventory.RemoveAt(i);
    //     }
    //     
    // }
    public void Eating(int slotId)
    {
        var uiSloth = slots.Find(slot => slot.id == slotId);
        uiSloth.Clear();

        var find = inventory.Find(item => item.id == uiSloth.itemThatIsInSLotId);
        inventory.Remove(find);
    }
}
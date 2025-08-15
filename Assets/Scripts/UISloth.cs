using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISloth : MonoBehaviour
{
    public PickupItem pickupItem;
    public int id;
    public int itemThatIsInSLotId;
    public Image image;
    public Button slothButton;
    private bool isEmpty = false;

    public void OnClick()
    {
        pickupItem.Eating(id);
    }

    public void SetImage(Sprite sprite)
    {
        slothButton.enabled = true;
        image.color = Color.white;
        image.sprite = sprite;
    }
    
    public bool IsEmpty() => isEmpty;

    public void Clear()
    {
        isEmpty = true;
        image.color = Color.clear;
        image.sprite = null;
        slothButton.enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipMentUnit : MonoBehaviour
{
    [SerializeField]
    private Button usebutton;
    [SerializeField]
    private Image icon;
    private InventoryItem inventory;

    public void AddItem(InventoryItem inventoryItem)
    {
        icon.enabled = true;
        usebutton.interactable = true;
        inventory = inventoryItem;
        icon.sprite = inventoryItem.data.icon;
    }

    public void RemoveItem()
    {
        usebutton.interactable = false;
        icon.enabled = false;
    }

    public void UseItem()
    {
        inventory.enable();
    }
}

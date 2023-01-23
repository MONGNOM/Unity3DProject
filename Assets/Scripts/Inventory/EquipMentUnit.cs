using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipMentUnit : MonoBehaviour
{
    private InventoryItem equipItem;

    [SerializeField]
    private Button useButton;
    [SerializeField]
    private Image icon;

    ItemData data;


    public void AddItem(InventoryItem inventoryItem)
    {
        icon.enabled = true;
        useButton.interactable = true;
        this.equipItem = inventoryItem;
        icon.sprite = equipItem.data.icon;
        Debug.Log("444");
    }

    public void RemoveItem()
    {
        useButton.interactable = false;
        icon.enabled = false;
    }

    public void UseItem()
    {
        Debug.Log("555");
        equipItem.UnEquip(equipItem);
    }

}

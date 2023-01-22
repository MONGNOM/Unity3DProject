using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemData data;

    public void InventoryGet()
    {  
        InventoryItem inventoryItem = new InventoryItem();
        inventoryItem.data = data;
        InventoryManager.Instance.AddItem(inventoryItem);

        Destroy(gameObject);
    }
}

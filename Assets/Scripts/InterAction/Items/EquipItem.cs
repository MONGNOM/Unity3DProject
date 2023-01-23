using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EquipItem : InventoryItem
{
    public ItemData eqiupData;

    public override void Use(InventoryItem inventoryItem)
    {
        // 인벤토리 매니저로 창작한다 구현
        //InventoryManager.Instance.AddItem(this);

        InventoryManager.Instance.UnEquipItem(inventoryItem);
        InventoryManager.Instance.AddItem(inventoryItem);

    }

}

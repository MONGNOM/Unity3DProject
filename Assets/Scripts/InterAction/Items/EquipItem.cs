using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EquipItem : InventoryItem
{
    public ItemData eqiupData;

    public override void Use(InventoryItem inventoryItem)
    {
        // �κ��丮 �Ŵ����� â���Ѵ� ����
        //InventoryManager.Instance.AddItem(this);

        InventoryManager.Instance.UnEquipItem(inventoryItem);
        InventoryManager.Instance.AddItem(inventoryItem);

    }

}

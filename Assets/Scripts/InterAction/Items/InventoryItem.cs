using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{

    public ItemData data;

    public virtual void Use()
    {
        InventoryManager.Instance.EquipItem(this);
    }

    public void enable()
    {
        InventoryManager.Instance.AddItme(this);
    }

}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryItem // �̰� ��ӹ޾Ƽ� use�� �������̵��ؼ� ����������̾ƴ϶� �����Ѵ�/ �Ǹ� ȸ���Ѵٷ� �Ѵ�
{
    public ItemData data;

    EquipItem equip;


    public virtual void Equip(InventoryItem inventoryItem)
    {
        if (data.type != ItemData.ItemType.equip)
            return;

        InventoryManager.Instance.EquipItem(inventoryItem);
        InventoryManager.Instance.RemoveItem(this);
    }
    public virtual void Use(InventoryItem inventoryItem)
    {
        if (data.type != ItemData.ItemType.potion)
            return;
    }

    public virtual void UnEquip(InventoryItem inventoryItem)
    {
        if (data.type != ItemData.ItemType.equip || data == null)
            return;

        InventoryManager.Instance.UnEquipItem(inventoryItem);
        InventoryManager.Instance.AddItem(inventoryItem);

    }

}

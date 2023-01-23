using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public InventoryUnit[] inventoryUnits;

    public void UpdateUi()
    {
        inventoryUnits = GetComponentsInChildren<InventoryUnit>();
        for (int i = 0; i < inventoryUnits.Length; i++)
        {
            if (i < InventoryManager.Instance.inventoryitems.Count)
            {
                // 아이템 갱신
                inventoryUnits[i].AddItem(InventoryManager.Instance.inventoryitems[i]);

            }
            else
            {
                // 아이템 비활성화
                inventoryUnits[i].RemoveItem();
            }
        }
    }
   
}

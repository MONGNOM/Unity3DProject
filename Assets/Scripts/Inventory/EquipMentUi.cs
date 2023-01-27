using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipMentUi : MonoBehaviour
{
    InventoryItem inventory;

    private EquipMentUnit[] equipMentUnits;
    
    [SerializeField] private EquipMentUnit weaponUnit,weapon1;
    [SerializeField] private EquipMentUnit ArmorUnit;
    [SerializeField] private EquipMentUnit AccessoryUnit;

    // 칼넣을땐 칼칸에 넣어주자?

    public void WeaponUpdateUi()
    {
        equipMentUnits = GetComponentsInChildren<EquipMentUnit>();

        for (int i = 0; i < equipMentUnits.Rank; i++)
        {
            if (i < InventoryManager.Instance.equipItems.Count) /////?????
            {
                if (weaponUnit.CheckItem())
                    weaponUnit.AddItem(InventoryManager.Instance.equipItems[i]);
                else
                    weapon1.AddItem(InventoryManager.Instance.equipItems[i]);
            }
            else
            {
                Debug.Log("333");
                weaponUnit.RemoveItem();
                weapon1.RemoveItem();
            }
        }
    }
    //public void ArmorUpdateUi()
    //{
    //    equipMentUnits = GetComponentsInChildren<EquipMentUnit>();

    //    for (int i = 0; i < equipMentUnits.Length; i++)
    //    {
    //        if (i < InventoryManager.Instance.equipItems.Count)
    //        {
    //            Debug.Log("222");
    //            // 아이템 갱신
    //            weaponUnit.AddItem(InventoryManager.Instance.inventoryitems[i]);
    //        }
    //        else
    //        {
    //            Debug.Log("333");
    //            // 아이템 비활성화
    //            weaponUnit.RemoveItem();
    //        }
    //    }
    //}
    //public void AccessoryUpdateUi()
    //{
    //    equipMentUnits = GetComponentsInChildren<EquipMentUnit>();

    //    for (int i = 0; i < equipMentUnits.Length; i++)
    //    {
    //        if (i < InventoryManager.Instance.equipItems.Count)
    //        {
    //            Debug.Log("222");
    //            // 아이템 갱신
    //            weaponUnit.AddItem(InventoryManager.Instance.inventoryitems[i]);
    //        }
    //        else
    //        {
    //            Debug.Log("333");
    //            // 아이템 비활성화
    //            weaponUnit.RemoveItem();
    //        }
    //    }
    //}

    //public void UpdateUi()
    //{
    //    equipMentUnits = GetComponentsInChildren<EquipMentUnit>(); 
        
    //    for (int i = 0; i < equipMentUnits.Length; i++)
    //    {
    //        if (i < InventoryManager.Instance.equipItems.Count)
    //        {
    //            Debug.Log("222");
    //            // 아이템 갱신
    //            equipMentUnits[i].AddItem(InventoryManager.Instance.equipItems[i]);
    //        }
    //        else
    //        {
    //            Debug.Log("333");
    //            // 아이템 비활성화
    //            equipMentUnits[i].RemoveItem();
    //        }
    //    }
    //}
}

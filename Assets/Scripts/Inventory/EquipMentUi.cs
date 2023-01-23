using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipMentUi : MonoBehaviour
{
    private EquipMentUnit[] equipMentUnits;

    public void UpdateUi()
    {
        equipMentUnits = GetComponentsInChildren<EquipMentUnit>();
        for (int i = 0; i < equipMentUnits.Length; i++)
        {
            if (i < InventoryManager.Instance.equipItems.Count)
            {
                Debug.Log("222");
                // 아이템 갱신
                equipMentUnits[i].AddItem(InventoryManager.Instance.equipItems[i]);
            }
            else
            {
                Debug.Log("333");
                // 아이템 비활성화
                equipMentUnits[i].RemoveItem();
            }
        }
    }
}

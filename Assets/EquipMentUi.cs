using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipMentUi : MonoBehaviour
{
    private EquipMentUnit[] equipUnits;

    public void UpdateEquip()
    {
        equipUnits = GetComponentsInChildren<EquipMentUnit>();

        for (int i = 0; i < equipUnits.Length; i++)
        {
            if (i < InventoryManager.Instance.items.Count)
            {
                //�����ۻ���
                equipUnits[i].AddItem(InventoryManager.Instance.items[i]);
            }
            
            else
            {
                equipUnits[i].RemoveItem();
                //������ĭ ��Ȱ��ȭ
            }


        }
    }
}

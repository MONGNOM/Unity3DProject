using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUnit : MonoBehaviour
{

    // ���� onClick���� ��ư Ŭ���� --> â���ϱ� ������ ui(��ư) --> ���� Onclick�� �ൿ �־��ֱ� 
    private InventoryItem inventoryItem;


    [SerializeField]
    private Button useButton;
    [SerializeField]
    private Image icon;

    ItemData data;


    public void AddItem(InventoryItem inventoryItem)
    {
        icon.enabled = true;
        useButton.interactable= true;
        this.inventoryItem = inventoryItem;
        icon.sprite = inventoryItem.data.icon;
    }

    public void RemoveItem()
    {
        icon.enabled = false;
        useButton.interactable = false;
    }

    public void UseItem()
    {
        //Item item = FindObjectOfType<Item>(); // �������� ������ ����� �� �� ����.
        //item.EquipGet(); // �κ��丮�� �ִ� �����͸� �־��ָ� �� �� ������ ==> �κ��丮�� ���� ���ͼ� �׷����ʾҳ�?
        inventoryItem.Use(inventoryItem);
        inventoryItem.Equip(inventoryItem);
    }

}

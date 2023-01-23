using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUnit : MonoBehaviour
{

    // 유닛 onClick에서 버튼 클릭시 --> 창작하기 버리기 ui(버튼) --> 각자 Onclick에 행동 넣어주기 
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
        //Item item = FindObjectOfType<Item>(); // 아이템이 없으면 사용할 수 가 없다.
        //item.EquipGet(); // 인벤토리에 있는 데이터를 넣어주면 될 것 같은데 ==> 인벤토리가 널이 나와서 그러지않았나?
        inventoryItem.Use(inventoryItem);
        inventoryItem.Equip(inventoryItem);
    }

}

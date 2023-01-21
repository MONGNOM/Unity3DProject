using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingleTon<InventoryManager>
{
    [SerializeField]
    private InventoryUI ui;
    private EquipMentUi equip;

    public List<InventoryItem> items = new List<InventoryItem>();


    private void Start()
    {
        ui = FindObjectOfType<InventoryUI>();
        equip = FindObjectOfType<EquipMentUi>();
        equip.gameObject.SetActive(false);
        ui.gameObject.SetActive (false);
        ui.UpdateUi ();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (ui.gameObject.activeSelf)
            {
                ui.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                ui.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            if (equip.gameObject.activeSelf)
            {
                equip.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                equip.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }


        }
    }
    public void AddItme(InventoryItem inventoryItem)
    {
        items.Add(inventoryItem);
        ui.UpdateUi();
    }

    public void DropItem(InventoryItem inventoryItem)
    {
        items.Remove(inventoryItem);
        ui.UpdateUi();

        Instantiate(inventoryItem.data.prefab);
    }

    public void EquipItem(InventoryItem inventoryItem)
    {

        items.Remove(inventoryItem);
        ui.UpdateUi();
    
        equip.UpdateEquip();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class InventoryManager : SingleTon<InventoryManager>
{
    public UnityEvent inventoryUpdateUI;
    
    [SerializeField]
    private InventoryUI inventoryUi;
    
    public List<InventoryItem> inventoryitems = new List<InventoryItem>();
    private void Start()
    {
        inventoryUi = FindObjectOfType<InventoryUI>();
        inventoryUi.UpdateUi();
        inventoryUi.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryUi.gameObject.activeSelf)
            {
                inventoryUi.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            { 
                inventoryUi.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void AddItem(InventoryItem inventoryitem)
    { 
        inventoryitems.Add(inventoryitem);
        inventoryUi.UpdateUi();
        //ㄴ 이걸로 바꿀예정 inventoryUpdateUI?.Invoke();
    }

    public void DropItem(InventoryItem inventoryItem)
    {
        Instantiate(inventoryItem.data.prefab);
        inventoryitems.Remove(inventoryItem);
        inventoryUi.UpdateUi();
        //ㄴ 이걸로 바꿀예정 inventoryUpdateUI?.Invoke();
    }


}

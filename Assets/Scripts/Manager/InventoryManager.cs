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
   

    public List<InventoryItem> equipItems = new List<InventoryItem>();
    public List<InventoryItem> inventoryitems = new List<InventoryItem>();

    [SerializeField]
    private EquipMentUi equipMentUi;

    public PlayerController playerController;



    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        inventoryUi = FindObjectOfType<InventoryUI>();
        equipMentUi = FindObjectOfType<EquipMentUi>();
        inventoryUi.gameObject.SetActive(false);
        equipMentUi.gameObject.SetActive(false);
        inventoryUi.UpdateUi();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (equipMentUi.gameObject.activeSelf)
            {
                equipMentUi.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                equipMentUi.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else if (Input.GetKeyDown(KeyCode.I))
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
        Debug.Log(inventoryitems[0].data.name);
        //ㄴ 이걸로 바꿀예정 inventoryUpdateUI?.Invoke();
    }

    public void RemoveItem(InventoryItem inventoryItem)
    {
        inventoryitems.Remove(inventoryItem);
        inventoryUi.UpdateUi();
        //ㄴ 이걸로 바꿀예정 inventoryUpdateUI?.Invoke();
    }

    public void DropItem(InventoryItem inventoryItem)
    {
        inventoryitems.Remove(inventoryItem);
        inventoryUi.UpdateUi();
        Instantiate(inventoryItem.data.prefab,playerController.transform.position,Quaternion.identity);
    }

    public void EquipItem(InventoryItem inventoryItem)
    {
        Debug.Log(inventoryItem);
        equipItems.Add(inventoryItem);
        equipMentUi.UpdateUi();
        Debug.Log(equipItems[0].data.name);
    }

    public void UnEquipItem(InventoryItem inventoryItem)
    {
        equipItems.Remove(inventoryItem);
        equipMentUi.UpdateUi();
    }


}

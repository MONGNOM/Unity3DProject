using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreUse : MonoBehaviour
{
    private void Awake()
    {
        InventoryManager inventoryManager = GetComponent<InventoryManager>();
    }

    public void storeuse()
    {
        //InventoryManager.Instance.StoreOpen();
    }

}

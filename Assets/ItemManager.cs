using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : SingleTon<ItemManager>
{
    [Header("����")]
    public Item item;
    public ItemData data;

    private void Start()
    {
        item = FindObjectOfType<Item>();
        data = FindObjectOfType<ItemData>();
    }

   


}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class ItemManager : SingleTon<ItemManager>
{
    [Header("¹«±â")]
    public Item item;
    public ItemData data;

    private void Start()
    {
        item = FindObjectOfType<Item>();
        data = FindObjectOfType<ItemData>();
    }

   


}

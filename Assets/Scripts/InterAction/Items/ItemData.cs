using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (menuName = "Item/Item")]
public class ItemData : ScriptableObject
{
    public new string name;
    public enum ItemType { equip,potion}
    public ItemType type;
    public string Description;
    public GameObject prefab;
    public Sprite icon;
}
    
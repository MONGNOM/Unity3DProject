using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (menuName = "Item/Item")]
public class ItemData : ScriptableObject
{
    public new string name;
    public enum ItemType { equip,potion}
    public ItemType itemtype;
    public enum EquipType { Weapon,Armor,Accessory}
    public EquipType equipType;
    public string Description;
    public GameObject prefab;
    public Sprite icon;
    public float damage;
    
}
    
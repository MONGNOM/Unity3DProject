using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryItem // 이걸 상속받아서 use를 오버라이드해서 드랍아이템이아니라 착용한다/ 피를 회복한다로 한다
{
    public ItemData data;

    public virtual void Use()
    {
        InventoryManager.Instance.DropItem(this);
    }
}

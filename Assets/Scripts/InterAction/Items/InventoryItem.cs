using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryItem // �̰� ��ӹ޾Ƽ� use�� �������̵��ؼ� ����������̾ƴ϶� �����Ѵ�/ �Ǹ� ȸ���Ѵٷ� �Ѵ�
{
    public ItemData data;

    public virtual void Use()
    {
        InventoryManager.Instance.DropItem(this);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : ClickableObject
{
    public Sprite m_InventorySprite;
    public int m_Uses;

    public virtual void Used()
    {
        m_Uses--;
        if (m_Uses == 0)
        {
            GameManager.Get.RemoveFromInventory(this);
            GameManager.Get.SelectInventoryItem(null);
        }
    }
}

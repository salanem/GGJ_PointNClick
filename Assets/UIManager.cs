using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Get { get; private set; }

    public Image[] m_FirstRowItems;
    public Image[] m_SecondRowItems;

    private void Awake()
    {
        if (Get != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Get = this;
    }

    private void Start()
    {
        DisplayInventoryItems(new PickableObject[0]);
    }

    public void SetInteractionType(int _type)
    {
        GameManager.Get.m_CurrentInteractionType = (EInteractionType)_type;
    }

    public void HightlightItem(int _index)
    {
        ResetHighlighting();
        if (_index < 3)
        {
            m_FirstRowItems[_index].color = Color.green;
            return;
        }
        m_SecondRowItems[_index - 3].color = Color.green;
    }

    public void DisplayInventoryItems(PickableObject[] _items)
    {
        for (int i = 0; i < 6; i++)
        {
            if (i < _items.Length)
            {
                if (i < 3)
                {
                    m_FirstRowItems[i].sprite = _items[i].m_InventorySprite;
                    m_FirstRowItems[i].enabled = true;
                    m_FirstRowItems[i].preserveAspect = true;
                }
                if (i > 2)
                {
                    m_SecondRowItems[i - 3].sprite = _items[i].m_InventorySprite;
                    m_FirstRowItems[i].enabled = true;
                    m_SecondRowItems[i - 3].preserveAspect = true;
                }
            }
            else
            {
                if (i < 3)
                {
                    m_FirstRowItems[i].sprite = null;
                    m_FirstRowItems[i].enabled = false;
                    m_FirstRowItems[i].preserveAspect = true;
                }
                if (i > 2)
                {
                    m_SecondRowItems[i - 3].sprite = null;
                    m_SecondRowItems[i - 3].enabled = false;
                    m_SecondRowItems[i - 3].preserveAspect = true;
                }
            }
        }
    }

    public void InventoryArrowUp()
    {
        GameManager.Get.InventoryRow++;
    }

    public void InventoryArrowDown()
    {
        GameManager.Get.InventoryRow--;
    }

    private void ResetHighlighting()
    {
        foreach (Image image in m_FirstRowItems)
        {
            image.color = Color.white;
        }

        foreach (Image image in m_SecondRowItems)
        {
            image.color = Color.white;
        }
    }
}

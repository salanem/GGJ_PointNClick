using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EInteractionType
{
    NONE = 0,
    OPEN,
    CLOSE,
    GIVE,
    PICK_UP,
    LOOK_AT,
    TALK_TO,
    PUSH,
    PULL,
    USE
}

public class GameManager : MonoBehaviour
{
    public static GameManager Get { get; private set; }

    public PickableObject CurrentInventoryItem
    {
        get
        {
            return m_currentInventoryItem;
        }
        set
        {
            // TODO: Highlight
            m_currentInventoryItem = value;
       //     UIManager.Get.SelectItem(m_displayedItems.IndexOf(m_currentInventoryItem));
        }
    }
    public int InventoryRow
    {
        get
        {
            return m_inventoryRow;
        }
        set
        {
            m_inventoryRow = Mathf.Clamp(value, 0, (m_inventoryItems.Count - 1) / 3);

            m_displayedItems = new List<PickableObject>();
            for (int i = 0; i < 6; i++)
            {
                if (m_inventoryRow * 3 + i < m_inventoryItems.Count)
                {
                    m_displayedItems.Add(m_inventoryItems[m_inventoryRow * 3 + i]);
                }
            }
            UIManager.Get.DisplayInventoryItems(m_displayedItems.ToArray());
        }
    }

    public EInteractionType m_CurrentInteractionType;
    public Dialog[] m_DefaultSuccessResponses;
    public Dialog[] m_DefaultFailedResponses;
    public float m_DefaultTextTime;

    private PickableObject m_currentInventoryItem;
    private int m_inventoryRow;
    private List<PickableObject> m_inventoryItems = new List<PickableObject>();
    private List<PickableObject> m_displayedItems;

    private void Awake()
    {
        if (Get != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Get = this;
    }

    private void OnGUI()
    {
        GUILayout.Label(m_CurrentInteractionType.ToString());
    }

    public void AddToInventory(PickableObject _object)
    {
        m_inventoryItems.AddUnique(_object);
        InventoryRow = InventoryRow;
    }

    public void RemoveFromInventory(PickableObject _object)
    {
        m_inventoryItems.Remove(_object);
        if (m_currentInventoryItem == _object)
        {
            SelectInventoryItem(null);
        }
        InventoryRow = InventoryRow;
    }

    public void SelectInventoryItem(PickableObject _object)
    {
        CurrentInventoryItem = _object;
    }

    public void SelectInventoryItem(int _index)
    {
        if (_index < 0)
        {
            CurrentInventoryItem = null;
            return;
        }
        CurrentInventoryItem = m_displayedItems[_index];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_index">Index in the visible item list</param>
    /// <returns></returns>
    public PickableObject GetObjectFromIndex(int _index)
    {
        if (_index >= 0 && _index < m_displayedItems.Count)
        {
            return m_displayedItems[_index];
        }
        return null;
    }
}

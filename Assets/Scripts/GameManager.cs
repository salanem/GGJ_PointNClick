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

    public EInteractionType m_CurrentInteractionType;
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
        }
    }

    private PickableObject m_currentInventoryItem;
    public string[] m_DefaultSuccessResponses;
    public string[] m_DefaultFailedResponses;
    public float m_DefaultTextTime;

    private void Awake()
    {
        if (Get != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Get = this;
    }

    public void AddToInventory(PickableObject _object)
    {

    }

    public void RemoveFromInventory(PickableObject _object)
    {

    }

    public void SelectInventoryItem(PickableObject _object)
    {
        CurrentInventoryItem = null;
    }
}

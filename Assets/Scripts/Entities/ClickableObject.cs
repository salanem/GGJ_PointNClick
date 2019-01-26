using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactions;

[DisallowMultipleComponent]
public class ClickableObject : MonoBehaviour
{
    public string m_ObjectName;
    public bool m_InitalActive;

    protected Dictionary<EInteractionType, Interaction> m_interactions = new Dictionary<EInteractionType, Interaction>();

    protected virtual void OnMouseEnter()
    {
        UIManager.Get.DisplayHoverItem(this);
    }

    protected virtual void OnMouseExit()
    {
        UIManager.Get.DisplayHoverItem(null);
    }

    protected virtual void OnMouseDown()
    {
        Interact();
    }

    public virtual void AddInteraction(Interaction _interaction)
    {
        if (_interaction.InteractionType == EInteractionType.NONE)
        {
            return;
        }
        if (m_interactions.ContainsKey(_interaction.InteractionType))
        {
            Debug.LogWarning($"{gameObject.name} already has an interaction for {_interaction.InteractionType}", this);
            return;
        }
        m_interactions.Add(_interaction.InteractionType, _interaction);
    }

    public virtual void Interact()
    {
        if (m_interactions.ContainsKey(GameManager.Get.m_CurrentInteractionType))
        {
            m_interactions[GameManager.Get.m_CurrentInteractionType].Interact();
            return;
        }
       GameManager.Get.DisplayFailResponse();
    }
}

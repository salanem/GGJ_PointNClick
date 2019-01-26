using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactions;

[DisallowMultipleComponent]
public class ClickableObject : MonoBehaviour
{
    public string m_ObjectName;
    public bool m_InitalActive;

    protected Dictionary<EInteractionType, List<Interaction>> m_interactions 
        = new Dictionary<EInteractionType, List<Interaction>>();

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
        if (!m_interactions.ContainsKey(_interaction.InteractionType))
        {
        m_interactions.Add(_interaction.InteractionType, new List<Interaction>());
        }
        m_interactions[_interaction.InteractionType].Add(_interaction);
    }

    public virtual void Interact()
    {
        if (m_interactions.ContainsKey(GameManager.Get.m_CurrentInteractionType))
        {
            foreach (Interaction interaction in m_interactions[GameManager.Get.m_CurrentInteractionType])
            {
                interaction.Interact();
            }
        }
       GameManager.Get.DisplayFailResponse();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Use Interaction", menuName = "Interaction/New Use Interaction")]
public class UseInteractionSettings : InteractionSettings
{
    public string CanBeUsedWith { get { return m_canBeUsedWith; } }
    public string UsedResponse { get { return m_usedResponse; } }

    protected string m_canBeUsedWith;
    protected string m_usedResponse;
}

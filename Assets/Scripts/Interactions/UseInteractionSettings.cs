using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Use Interaction", menuName = "Interaction/New Use Interaction")]
public class UseInteractionSettings : InteractionSettings
{
    public string CanBeUsedWith { get { return m_canBeUsedWith; } }
    public Dialog UsedResponse { get { return m_usedResponse; } }

    protected string m_canBeUsedWith;
    protected Dialog m_usedResponse;
}

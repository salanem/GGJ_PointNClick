using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Response", menuName = "Data/Response")]
public class Response : ScriptableObject
{
    public Dialog[] m_PossibleDialogs;
    public bool m_PlayAll;
    public bool m_PlayInOrder;
    public bool m_PseudoRandom;
    public bool m_RepeatWhole;
    public bool m_RepeatLast;
}

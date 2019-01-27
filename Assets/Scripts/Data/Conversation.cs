using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Conversation", menuName = "Data/Conversation")]
public class Conversation : ScriptableObject
{
    public Choice m_StartChoice;
}

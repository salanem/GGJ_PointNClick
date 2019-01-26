using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation")]
public class Conversation : ScriptableObject
{
    public Choice m_StartChoice;
}

[CreateAssetMenu(fileName = "New Choice", menuName = "Choice")]
public class Choice : ScriptableObject
{
    public string[] m_Options;
    public Dialog[] m_Answers;
    public Choice m_FollowUp;
}

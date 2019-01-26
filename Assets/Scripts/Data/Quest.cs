using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Data/Quest", order = 3)]
public class Quest : ScriptableObject
{
    public string QuestName { get { return m_questName; } }
    public string Goal { get { return m_goal; } }
    public string[] Locations { get { return m_locations; } }
    public Quest FollowUpQuest { get { return m_followUpQuest; } }

#pragma warning disable 0649
    // will be Assigned in the editor
    [SerializeField]
    private string m_questName;
    [SerializeField]
    private string m_goal;
    [SerializeField]
    private string[] m_locations;
    [SerializeField]
    private Quest m_followUpQuest;
#pragma warning restore
}

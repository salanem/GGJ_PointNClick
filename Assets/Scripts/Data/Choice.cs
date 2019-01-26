using UnityEngine;

[CreateAssetMenu(fileName = "New Choice", menuName = "Choice")]
public class Choice : ScriptableObject
{
    public string[] m_Options;
    public Dialog[] m_Answers;
    public Choice m_FollowUp;
}

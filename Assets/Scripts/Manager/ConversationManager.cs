using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationManager : MonoBehaviour
{
    public static ConversationManager Get { get; private set; }

    private Conversation m_currentConversation;
    public Choice m_currentChoice;

    private void Awake()
    {
        if (Get != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Get = this;
    }

    public void StartConversation(Conversation _conversation)
    {
        m_currentConversation = _conversation;
        m_currentChoice = _conversation.m_StartChoice;
        UIManager.Get.DisplayChoice(m_currentChoice);
    }

    public void ChoseChoice(int _index)
    {
        if (_index < 0 || _index > 2)
        {
            return;
        }
        DialogManager.Get.PlayDialog(m_currentChoice.m_Answers[_index], null);
        m_currentChoice = m_currentChoice.m_FollowUps[_index];
        UIManager.Get.DisplayChoice(m_currentChoice);
        Debug.Log(m_currentChoice);
    }
}

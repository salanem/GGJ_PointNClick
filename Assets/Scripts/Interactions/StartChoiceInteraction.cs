using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{
    public class StartChoiceInteraction : Interaction
    {
        public Conversation Conversation
        {
            get
            {
                return m_conversation;
            }
        }

#pragma warning disable 0649
        // will be Assigned in the editor
        [SerializeField]
        private Conversation m_conversation;
#pragma warning restore
        public override void Interact()
        {
            base.Interact();
            ConversationManager.Get.StartConversation(m_conversation);
        }
    }
}
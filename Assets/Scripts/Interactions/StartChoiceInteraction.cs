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

        [SerializeField]
        private Conversation m_conversation;

        public override void Interact()
        {
            base.Interact();
            ConversationManager.Get.StartConversation(m_conversation);
        }
    }
}
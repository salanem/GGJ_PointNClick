using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{
    public class ConversationInteraction : Interaction
    {
       public Conversation StartConversation { get { return m_startConversation; } }

        [SerializeField]
        private Conversation m_startConversation;

        public override void OnDialogEvent(Dialog _dialog)
        {
            base.OnDialogEvent(_dialog);
            if (_dialog.m_DialogEventType == EDialogEventType.CUSTOM)
            {
                ConversationManager.Get.StartConversation(StartConversation);
            }
        }
    }
}
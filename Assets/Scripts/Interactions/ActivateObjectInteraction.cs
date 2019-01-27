using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{
    public class ActivateObjectInteraction : Interaction
    {
        public ClickableObject m_ToActivate;

        public override void OnDialogEvent(Dialog _dialog)
        {
            base.OnDialogEvent(_dialog);
            if (_dialog.m_DialogEventType == EDialogEventType.CUSTOM)
            {
                m_ToActivate.gameObject.SetActive(true);
            }
        }
    }
}
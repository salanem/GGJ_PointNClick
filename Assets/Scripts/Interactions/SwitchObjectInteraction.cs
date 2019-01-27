using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{
    public class SwitchObjectInteraction : Interaction
    {
        public ClickableObject ToActivate
        {
            get
            {
                return m_toActivate;
            }
        }

#pragma warning disable 0649
        // Assigned in the editor
        [SerializeField]
        private ClickableObject m_toActivate;
#pragma warning restore 0649

        public override void Interact()
        {
            base.Interact();
        }

        public override void OnDialogEvent(Dialog _dialog)
        {
            base.OnDialogEvent(_dialog);
            if (_dialog.m_DialogEventType == EDialogEventType.CUSTOM)
            {
                ToActivate.gameObject.SetActive(true);
                gameObject.SetActive(false);
                UIManager.Get.DisplayHoverItem(null);
            }
        }
    }
}

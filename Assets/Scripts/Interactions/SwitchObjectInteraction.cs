using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{
    public class SwitchObjectInteraction : Interaction
    {
        public List<ClickableObject> ToActivate
        {
            get
            {
                return m_toActivate;
            }
        }

#pragma warning disable 0649
        // Assigned in the editor
        [SerializeField]
        private List<ClickableObject> m_toActivate;
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
                foreach (ClickableObject toActivate in m_toActivate)
                {
                    toActivate.gameObject.SetActive(true);
                }
                gameObject.SetActive(false);
                UIManager.Get.DisplayHoverItem(null);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{
    public class UseObjectInteraction : Interaction
    {
        public string RequiredObjectName { get { return m_requiredObjectName; } }
        public ClickableObject ToActivate { get { return m_toActivate; } }

#pragma warning disable 0649
        // Assigned in the editor
        [SerializeField]
        private ClickableObject m_toActivate;
#pragma warning restore 0649
        [SerializeField]
        protected string m_requiredObjectName;

        public override void Interact()
        {
            if (string.IsNullOrWhiteSpace(RequiredObjectName))
            {
                base.Interact();
            }
            else if (GameManager.Get.CurrentInventoryItem != null
                && RequiredObjectName == GameManager.Get.CurrentInventoryItem.m_ObjectName)
            {
                base.Interact();
            }
            else
            {
                if (m_settings.FailResponse != null && m_settings.FailResponse.
                        m_PossibleDialogs.Length > 0)
                {
                    ShowResponse(m_settings.FailResponse);
                }
                else
                {
                    GameManager.Get.DisplayFailResponse();
                }
            }
        }

        public override void OnDialogEvent(Dialog _dialog)
        {
            base.OnDialogEvent(_dialog);

            if (_dialog.m_DialogEventType == EDialogEventType.CUSTOM)
            {
                if (string.IsNullOrWhiteSpace(RequiredObjectName))
                {
                    ToActivate?.gameObject.SetActive(true);
                    gameObject.SetActive(false);
                    UIManager.Get.DisplayHoverItem(null);
                    GameManager.Get.CurrentInventoryItem.Used();
                }
                else if (RequiredObjectName == GameManager.Get.CurrentInventoryItem.m_ObjectName)
                {
                    ToActivate?.gameObject.SetActive(true);
                    gameObject.SetActive(false);
                    UIManager.Get.DisplayHoverItem(null);
                    GameManager.Get.CurrentInventoryItem.Used();
                }
            }
        }
    }
}

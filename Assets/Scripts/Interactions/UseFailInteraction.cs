using UnityEngine;

namespace Interactions
{
    public class UseFailInteraction : Interaction
    {
        public string RequiredObjectName { get { return m_requiredObjectName; } }

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
                ShowResponse(m_settings.SuccessResponse);
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

    }
}

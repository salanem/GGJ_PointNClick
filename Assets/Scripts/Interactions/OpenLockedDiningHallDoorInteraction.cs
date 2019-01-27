using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{
    public class OpenLockedDiningHallDoorInteraction : UseObjectInteraction
    {
        public override void OnDialogEvent(Dialog _dialog)
        {
            base.OnDialogEvent(_dialog);
            if (_dialog.m_DialogEventType == EDialogEventType.CUSTOM)
            {
                GameManager.Get.IsDiningHallDoorOpen = true;
            }
        }
    }
}

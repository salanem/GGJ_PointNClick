using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDialogOnStart : MonoBehaviour
{
    public Dialog m_Dialog;

    // Start is called before the first frame update
    void Start()
    {
        if (!GameManager.Get.HasDialogBeenPlayed(m_Dialog))
        {
            DialogManager.Get.PlayDialog(m_Dialog, null);
        }
            
    }

   
}

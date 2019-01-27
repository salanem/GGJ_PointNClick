using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCompleted : MonoBehaviour
{
    public bool m_OnEnable;

    private void OnEnable()
    {
        if (m_OnEnable)
        {
            GameManager.Get.QuestFinished();
        }
    }

    private void OnDisable()
    {
        if (!m_OnEnable)
        {
            GameManager.Get.QuestFinished();
        }
    }
}

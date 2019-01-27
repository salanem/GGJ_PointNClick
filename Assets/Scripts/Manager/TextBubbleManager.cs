using System.Collections;
using System.Collections.Generic;
using TimeUtilities;
using UnityEngine;

public class TextBubbleManager : MonoBehaviour
{
    public static TextBubbleManager Get { get; private set; }

    private RepeatingCountdown m_countdown;

    private void Awake()
    {
        if (Get != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Get = this;
    }
    
    public void DisplayTextBubble(string _text)
    {
        string text = _text.Replace("[[Protagonist]]", "John Luke");
        text = text.Replace("Protagonist", "John Luke");
        UIManager.Get.DisplayText(text);
    }
}

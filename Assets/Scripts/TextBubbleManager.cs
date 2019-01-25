using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBubbleManager : MonoBehaviour
{
    public static TextBubbleManager Get { get; private set; }

    private void Awake()
    {
        if (Get != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Get = this;
    }
    
    public void DisplayTextBubble(string _text, float _displayTime)
    {

    }
}

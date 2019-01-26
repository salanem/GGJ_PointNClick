using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog", menuName = "Data/New Dialog")]
public class Dialog : ScriptableObject
{
    public AudioClip[] m_AudioClips;
    public TextInfo[] m_Text;
    public bool m_AutoPlay;
    public float m_TimeBetweenClips;
    public bool m_TriggerDialogEvent;
    public EDialogEventType m_DialogEventType;
}

public enum EDialogEventType
{
    NONE,
    FADE_IN,
    FADE_OUT,
    CUSTOM
}

[System.Serializable]
public struct TextInfo
{
    public string m_Speaker;
    [Multiline(5)]
    public string m_Text;

    public TextInfo(string _speaker, string _text)
    {
        m_Speaker = _speaker;
        m_Text = _text;
    }

    public override string ToString()
    {
        return $"{m_Speaker}: {m_Text}";
    }
}

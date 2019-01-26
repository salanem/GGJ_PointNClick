using System.Collections.Generic;
using TimeUtilities;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DialogManager : MonoBehaviour
{
    public static DialogManager Get { get; private set; }

    private void Awake()
    {
        if (Get != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Get = this;
        m_audioSource = GetComponent<AudioSource>();
    }

    private Dialog m_currentDialog;
    private AudioSource m_audioSource;
    private int m_index;
    private RepeatingCountdown m_countdown;

    private void Update()
    {
        if (m_currentDialog != null)
        {
            if (m_currentDialog.m_AutoPlay)
            {
                if (!m_audioSource.isPlaying)
                {
                    if (m_countdown.Tick())
                    {
                        m_index++;
                        if (!NextSection())
                        {
                            m_currentDialog = null;
                        }
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    m_index++;
                    if (!NextSection())
                    {
                        m_currentDialog = null;
                    }
                }
            }
        }
    }

    public void PlayDialog(Dialog _dialog)
    {
        if (_dialog == null)
        {
            return;
        }
        m_audioSource.Stop();
        m_countdown = new RepeatingCountdown(_dialog.m_TimeBetweenClips);
        m_currentDialog = _dialog;
        m_index = 0;
        if (!NextSection())
        {
            m_currentDialog = null;
        }
    }

    public void StopDialog()
    {
        m_audioSource.Stop();
        m_currentDialog = null;
    }
    private bool NextSection()
    {
        bool playedSomething = false;
        m_audioSource.Stop();
        if (m_currentDialog.m_Text.Length > m_index)
        {
            TextBubbleManager.Get.DisplayTextBubble(m_currentDialog.m_Text[m_index].ToString(), -1);
            playedSomething = true;
        }
        if (m_currentDialog.m_AudioClips.Length > m_index)
        {
            m_audioSource.PlayOneShot(m_currentDialog.m_AudioClips[m_index]);
            playedSomething = true;
        }
        return playedSomething;
    }
}

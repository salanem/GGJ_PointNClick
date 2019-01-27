using Interactions;
using System.Collections;
using System.Collections.Generic;
using TimeUtilities;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DialogManager : MonoBehaviour
{
    public static DialogManager Get { get; private set; }

    public bool IsPlayingDialog
    {
        get
        {
            return m_currentDialog != null;
        }
    }

    private Dialog m_currentDialog;
    private AudioSource m_audioSource;
    private int m_index;
    private RepeatingCountdown m_countdown;
    private Coroutine m_playAllCoroutine;
    private Interaction m_currentInteraction;

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

    public void PlayDialog(Dialog _dialog, Interaction _interaction)
    {
        if (_dialog == null)
        {
            return;
        }
        m_currentInteraction = _interaction;
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

    public void PlayAllDialogs(List<Dialog> _dialogs, Interaction _interaction)
    {
        StopDialog();
        m_currentInteraction = _interaction;
        m_playAllCoroutine = StartCoroutine(PlayAll(_dialogs));
    }

    private IEnumerator PlayAll(List<Dialog> _dialogs)
    {
        while (_dialogs.Count > 0)
        {
            yield return new WaitUntil(() =>
            !IsPlayingDialog);
            if (_dialogs[0].m_AudioClips.Length == 0 &&
                _dialogs[0].m_Text.Length == 0)
            {
                yield return new WaitForSeconds(1.0f);
            }
            PlayDialog(_dialogs[0], m_currentInteraction);
            _dialogs.RemoveAt(0);
        }
        m_playAllCoroutine = null;
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
            if (m_currentDialog.m_AudioClips[m_index] != null)
            {
                m_audioSource.PlayOneShot(m_currentDialog.m_AudioClips[m_index]);
                playedSomething = true;
            }
        }
        if (!playedSomething && m_currentInteraction != null)
        {
            if (m_currentDialog.m_TriggerDialogEvent
                && m_currentDialog.m_DialogEventType != EDialogEventType.NONE)
            {
                m_currentInteraction.OnDialogEvent(m_currentDialog);
            }
        }
        return playedSomething;
    }
}

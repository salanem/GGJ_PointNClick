using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public float m_FadeDuration;

    private float m_targetVolume;
    private AudioSource m_audioSource;
    private void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_targetVolume = m_audioSource.volume;
        StartCoroutine(AsyncFadeIn());
    }

    private IEnumerator AsyncFadeIn()
    {
        float time = 0;
        m_audioSource.volume = 0;
        while (time < 1)
        {
            m_audioSource.volume = Mathf.SmoothStep(0, m_targetVolume, time);
            time += Time.deltaTime / m_FadeDuration;
            yield return null;
        }
        m_audioSource.volume = m_targetVolume;
    }
}

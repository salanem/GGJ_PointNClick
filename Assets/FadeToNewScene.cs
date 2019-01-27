using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FadeToNewScene : MonoBehaviour
{
    public float m_FadeDuration;

    private AudioSource m_audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        m_audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(UnityEngine.SceneManagement.Scene arg0, UnityEngine.SceneManagement.LoadSceneMode arg1)
    {
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        float time = 1;
        float startVolume = m_audioSource.volume;
        while (time > 0)
        {
            m_audioSource.volume = Mathf.SmoothStep(0, startVolume, time);
            time -= Time.deltaTime / m_FadeDuration;
            yield return null;
        }
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Scene m_UIScene;
    public Scene m_StartScene;

    public AudioMixer m_AudioMixer;

    public void StartGame()
    {
        SceneManager.LoadScene(m_UIScene);
        SceneManager.LoadScene(m_StartScene, LoadSceneMode.Additive);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void MasterVolumeChanged(float _value)
    {
        m_AudioMixer.SetFloat("MasterVolume", _value);
    }

    public void MusicVolumeChanged(float _value)
    {
        m_AudioMixer.SetFloat("MusicVolume", _value);
    }

    public void AmbientVolumeChanged(float _value)
    {
        m_AudioMixer.SetFloat("AmbientVolume", _value);
    }

    public void EffectVolumeChanged(float _value)
    {
        m_AudioMixer.SetFloat("EffectVolume", _value);
    }

    public void VoiceVolumeChanged(float _value)
    {
        m_AudioMixer.SetFloat("VoiceVolume", _value);
    }
}

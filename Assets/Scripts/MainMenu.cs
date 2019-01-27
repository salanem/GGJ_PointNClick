using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Scene m_UIScene;
    public Scene m_StartScene;

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
}

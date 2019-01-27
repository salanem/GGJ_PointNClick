using System.Collections;
using System.Collections.Generic;
using TimeUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneAfterTime : MonoBehaviour
{
    public Countdown m_TimeUntilSceneSwitch;
    public bool m_LoadBoth;
    public Scene m_StartScene;
    public Scene m_UIScene;

    // Update is called once per frame
    void Update()
    {
        if (m_TimeUntilSceneSwitch.Tick())
        {
            if (m_LoadBoth)
            {
                SceneManager.LoadScene(m_UIScene);
                SceneManager.LoadScene(m_StartScene, LoadSceneMode.Additive);
            }
            else
            {
                SceneManager.LoadScene(m_StartScene);
            }
        }
    }
}

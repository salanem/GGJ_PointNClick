using UnityEngine;

[System.Serializable]
public class Scene
{
    public string Path
    {
        get
        {
            return m_scenePath;
        }
    }

    public string Name
    {
        get
        {
            return m_sceneName;
        }
    }

    public int BuildIndex
    {
        get
        {
            return m_buildIndex;
        }
    }

    // Will be assigned through the editor.
    [SerializeField]
#pragma warning disable 0649
    private string m_scenePath;
#pragma warning restore 0649
    [SerializeField]
    private Object m_sceneObject;
    [SerializeField]
    // Will be assigned through the editor.
#pragma warning disable 0649
    private string m_sceneName;
#pragma warning restore 0649
    // Will be assigned through the editor.
    [SerializeField]
#pragma warning disable 0649
    private int m_buildIndex;
#pragma warning restore 0649

    public override string ToString()
    {
        return $"{Name}[{Path}({BuildIndex})]";
    }

    public static implicit operator string(Scene _scene)
    {
        return _scene.Path;
    }
}

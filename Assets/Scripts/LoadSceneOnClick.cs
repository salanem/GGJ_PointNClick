using UnityEngine;

public class LoadSceneOnClick : MonoBehaviour
{
    public Scene m_Scene;

    protected virtual void OnMouseDown()
    {
        GameManager.Get.LoadRoom(m_Scene);
    }
}

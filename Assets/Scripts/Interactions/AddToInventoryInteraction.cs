using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Interactions
{
    public class AddToInventoryInteraction : Interaction
    {
        public override void Interact()
        {
            base.Interact();
            PickableObject pickable = GetComponent<PickableObject>();
            if (pickable != null )
            {
                GameManager.Get.AddToInventory(pickable);
                UnityEngine.SceneManagement.Scene uiScene = new UnityEngine.SceneManagement.Scene();
                UnityEngine.SceneManagement.Scene tmpScene;

                for (int i = 0; i < SceneManager.sceneCount; i++)
                {
                    tmpScene = SceneManager.GetSceneAt(i);
                    if (tmpScene.name == "UIScene")
                    {
                        uiScene = tmpScene;
                    }
                }
                SceneManager.MoveGameObjectToScene(gameObject, uiScene);
                gameObject.SetActive(false);
            }
        }
    }
}
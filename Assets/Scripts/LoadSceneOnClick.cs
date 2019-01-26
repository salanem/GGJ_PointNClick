using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.Scripts
{
    public class LoadSceneOnClick : MonoBehaviour
    {
        public Scene m_Scene;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameManager.Get.LoadRoom(m_Scene);
            }
        }
    }
}

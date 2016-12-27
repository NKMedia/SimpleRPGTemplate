using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NKM.RPGFramework
{
    public class CloseGame : MonoBehaviour
    {
        public SceneController sceneController;

        void Start()
        {
            sceneController = FindObjectOfType<SceneController>();
        }

        public void QuitGame()
        {
            Application.Quit();
            sceneController.FadeOutEndGame();
        }

    }
}

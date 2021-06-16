using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RedBall
{
    public class MainMenuManager : MonoBehaviour
    {
        public void OnCLickLevel()
        {
            SceneManager.LoadScene(SceneName.Level.ToString());
        }
        public void OnCLickMultiplayer()
        {
            SceneManager.LoadScene(SceneName.Multiplayer.ToString());
        }
        public void OnCLickExit()
        {
            Application.Quit();
        }
    }

}

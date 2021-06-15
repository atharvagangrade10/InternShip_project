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
            SceneManager.LoadScene(0);
        }
        public void OnCLickMultiplayer()
        {

        }
        public void OnCLickExit()
        {
            Application.Quit();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedBall
{
    public class player1Strip : MonoBehaviour
    {
        public WinScript winScript;
        public GameObject ownerHud;
        private void Start()
        {
            winScript = GameObject.FindGameObjectWithTag("wins").GetComponent<WinScript>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                winScript.modifyWinPanel(true);
                winScript.modifyWinText1();
                ownerHud.SetActive(false);
                winScript.OnReachEnd();
                Time.timeScale = 0;                
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                winScript.modifyWinPanel(true);
                winScript.modifyWinText1();
                ownerHud.SetActive(false);
                winScript.OnReachEnd();
                Time.timeScale = 0;
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                winScript.modifyWinPanel(true);
                winScript.modifyWinText1();
                ownerHud.SetActive(false);
                winScript.OnReachEnd();
                Time.timeScale = 0;
            }
        }
    }
}


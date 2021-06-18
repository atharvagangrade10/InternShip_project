using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RedBall
{
    public class WinScript : MonoBehaviourPun
    {
        public Text winText;
        // Start is called before the first frame update
        void Start()
        {
            transform.parent.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void modifyWinText1()
        {
            photonView.RPC("changeWinText1", RpcTarget.AllBuffered);
        }
        public void modifyWinText2()
        {
            photonView.RPC("changeWinText2", RpcTarget.AllBuffered);
        }
        [PunRPC]
        void changeWinText1()
        {
            winText.text = "Player 1 Win";
        }
        [PunRPC]
        void changeWinText2()
        {
            winText.text = "Player 2 Win";
        }
        public void modifyWinPanel(bool active)
        {
            photonView.RPC("ActiveWinPanel", RpcTarget.AllBuffered,active);
        }
        [PunRPC]
        void ActiveWinPanel(bool active)
        {
            transform.parent.gameObject.SetActive(active);
            gameObject.SetActive(active);
        }
        
        public void OnReachEnd()
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("HUD");
            for (int i = 0; i < objects.Length; i++)
            {
                Destroy(objects[i]);
            }
        }
    }
}


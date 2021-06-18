using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RedBall
{
    public class textchanger : MonoBehaviourPun
    {
        private Text text;
        public Image fillImage;
        private int count;
        private playercontroller playercontroller;
        private PlayersMultiplayer multiplayer;
        // Start is called before the first frame update
        void Start()
        {
            text = GetComponent<Text>();
            playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<playercontroller>();
            multiplayer = GameObject.FindGameObjectWithTag("Multiplayer").GetComponent<PlayersMultiplayer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (photonView.IsMine)
            {
                if (fillImage.fillAmount == 1)
                {
                    count++;
                    photonView.RPC("changeText", RpcTarget.AllBuffered, count);
                }
            }

        }
        [PunRPC]
        public void changeText(int count)
        {

            text.text = "" + count;
            if (multiplayer.player1Turn)
            {
                playercontroller.modifyPosition(-count);
            }
            if (multiplayer.player2Turn)
            {
                playercontroller.modifyPosition(count);
            }
            count = 0;
            fillImage.fillAmount = .04f;

        }
    }
}


using Photon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Photon.Pun;

namespace RedBall
{

    public class PlayersMultiplayer : MonoBehaviourPun
    {
        public bool player1Turn;
        public bool player2Turn;
        public Text turnText;
        // Start is called before the first frame update
        void Start()
        {
            player1Turn = true;
            player2Turn = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (photonView.IsMine)
            {
                photonView.RPC("changeTurnText", RpcTarget.AllBuffered);
            }
        }
        public void modifyTurns(string selectPlayer)
        {
            photonView.RPC("changeTurn", RpcTarget.AllBuffered, selectPlayer);
        }
        [PunRPC]
        void changeTurn(string selectPlayer)
        {
            player1Turn = selectPlayer.Equals(player1Turn.ToString());
            player2Turn = selectPlayer.Equals(player2Turn.ToString());
        }
        [PunRPC]
        void changeTurnText()
        {
            if (player1Turn)
            {
                turnText.text = "Player 1 turn";
            }
            if (player2Turn)
            {
                turnText.text = "Player 2 turn";
            }
        }
       
    }



}

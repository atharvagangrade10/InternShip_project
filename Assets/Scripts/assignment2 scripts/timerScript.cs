using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RedBall
{
    public class timerScript : MonoBehaviourPun
    {
        public int maxTimer;
        public float timerCount;
        private Text text;

        public PlayersMultiplayer playersControllers;
        // Start is called before the first frame update
        void Start()
        {
            timerCount = maxTimer;
            text = GetComponent<Text>();
            playersControllers = GameObject.FindGameObjectWithTag("Multiplayer").GetComponent<PlayersMultiplayer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (photonView.IsMine)
            {
                if (timerCount > 0)
                {
                    timerCount -= Time.deltaTime*1.2f;
                }
                photonView.RPC("time", RpcTarget.AllBuffered,timerCount);
            }            
        }

        [PunRPC]
        void time(float timercount)
        {
            if (timerCount < 0)
            {
                if (playersControllers.player1Turn)
                {
                    playersControllers.modifyTurns(playersControllers.player2Turn.ToString());
                }
                else
                {
                    playersControllers.modifyTurns(playersControllers.player1Turn.ToString());
                }
                text.text = "finish";
                timerCount = maxTimer;
            }
            else
            {
                text.text = "" + (int)timercount;
            }
            
        }
    }

}

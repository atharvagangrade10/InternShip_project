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
        // Start is called before the first frame update
        void Start()
        {
            timerCount = maxTimer;
            text = GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            if (photonView.IsMine)
            {
                if (timerCount > 0)
                {
                    timerCount -= Time.deltaTime*1.5f;
                }
                photonView.RPC("time", RpcTarget.AllBuffered,timerCount);
            }            
        }

        [PunRPC]
        void time(float timercount)
        {
            if (timerCount == 0)
            {
                text.text = "finish";
            }
            else
            {
                text.text = "" + (int)timercount;
            }
            
        }
    }

}

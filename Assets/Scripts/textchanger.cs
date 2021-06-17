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
        // Start is called before the first frame update
        void Start()
        {
            text = GetComponent<Text>();
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
            fillImage.fillAmount = .04f;

        }
    }
}


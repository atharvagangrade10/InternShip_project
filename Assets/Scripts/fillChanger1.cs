using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

namespace RedBall
{
    public class fillChanger1 : MonoBehaviourPun
    {
        private Image fillImage;
        // Start is called before the first frame update
        void Start()
        {
            fillImage = GetComponent<Image>();
        }

        // Update is called once per frame
        void Update()
        {
            if (photonView.IsMine)
            {
                if (CrossPlatformInputManager.GetButtonDown("Play"))
                { 
                    photonView.RPC("fillchange1", RpcTarget.AllBuffered);
                }
            }

        }
        [PunRPC]
        void fillchange1()
        {
            fillImage.fillAmount += .03f;
        }

    }
}

using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

namespace RedBall
{
    /// <summary>
    ///  This class fills the players bar on taps
    /// </summary>
    public class fillChanger : MonoBehaviourPun
    {
        private Image fillImage;
        public PlayersMultiplayer playercontroller;
        // Start is called before the first frame update
        void Start()
        {
            fillImage = GetComponent<Image>();
            playercontroller = GameObject.FindGameObjectWithTag("Multiplayer").GetComponent<PlayersMultiplayer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (photonView.IsMine)
            {
                if (CrossPlatformInputManager.GetButtonDown("Play"))
                {
                    if (playercontroller.player1Turn)
                    {
                        if (PhotonNetwork.IsMasterClient)
                        {
                            photonView.RPC("fillchange", RpcTarget.AllBuffered);
                        }
                    }
                    if (playercontroller.player2Turn)
                    {
                        if (!PhotonNetwork.IsMasterClient)
                        {
                            photonView.RPC("fillchange", RpcTarget.AllBuffered);
                        }
                    }
                    
                }

            }
        }
        [PunRPC]
        void fillchange()
        {
            fillImage.fillAmount += .03f;
        }
    }

}

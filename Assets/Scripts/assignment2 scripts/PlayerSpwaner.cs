using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedBall
{
    public class PlayerSpwaner : MonoBehaviour
    {
        private GameObject playArea1;
        private GameObject playArea2;
        private GameObject winPanel;

        // Start is called before the first frame update
        void Start()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                playArea1 = PhotonNetwork.Instantiate("HUD1", Vector3.zero, Quaternion.identity);
            }
            else
            {
                playArea2 = PhotonNetwork.Instantiate("HUD2", Vector3.zero, Quaternion.identity);
                
            }
            winPanel = PhotonNetwork.Instantiate("winPanel", Vector3.zero, Quaternion.identity);
        }

        // Update is called once per frame
        void Update()
        {

        }
        void destroyWinPanel()
        {
            Destroy(winPanel);
        }
    }

}

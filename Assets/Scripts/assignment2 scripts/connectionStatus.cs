using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RedBall
{
    public class connectionStatus : MonoBehaviour
    {
        private readonly string connectionStatusMessage = "Connection Status: ";

        [Header("UI References")]
        public Text ConnectionStatusText;
        public bool debug;
        #region UNITY
        private void Start()
        {
            ConnectionStatusText.text = connectionStatusMessage;
        }
        public void Update()
        {
            if (debug)
            {
                ConnectionStatusText.text = connectionStatusMessage + PhotonNetwork.NetworkClientState;
            }
            else
            {
                if (PhotonNetwork.NetworkClientState == Photon.Realtime.ClientState.ConnectedToMasterServer)
                {
                    ConnectionStatusText.text = connectionStatusMessage + "Connected";
                }
                else if (PhotonNetwork.NetworkClientState == Photon.Realtime.ClientState.PeerCreated)
                {
                    ConnectionStatusText.text = connectionStatusMessage;
                }
                else if (PhotonNetwork.NetworkClientState == Photon.Realtime.ClientState.Disconnecting)
                {
                    ConnectionStatusText.text = connectionStatusMessage + "Disconnecting.....";
                }
                else if (PhotonNetwork.NetworkClientState == Photon.Realtime.ClientState.Disconnected)
                {
                    ConnectionStatusText.text = connectionStatusMessage + "Disconnected";
                }
                else if (PhotonNetwork.NetworkClientState == Photon.Realtime.ClientState.Joined)
                {
                    ConnectionStatusText.text = connectionStatusMessage + "joined";
                }
                else if (PhotonNetwork.NetworkClientState == Photon.Realtime.ClientState.Leaving)
                {
                    ConnectionStatusText.text = connectionStatusMessage + "leaving..";
                }
                else
                {
                    ConnectionStatusText.text = connectionStatusMessage + "Connecting.....";
                }
            }
            
            
        }
        #endregion
    }

}

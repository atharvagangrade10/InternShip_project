using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RedBall
{
    /// <summary>
    /// This class is used to leave the multiplayer game
    /// </summary>
    public class leaveGame : MonoBehaviourPun
    {
        int count = 0;
        public void OnCLickLeaveRoom()
        {
            if (photonView.IsMine && count == 0)
            {
                count++;
                PhotonNetwork.Disconnect();
                if (PhotonNetwork.IsConnected)
                {
                    wait();
                }
                else
                {
                    SceneManager.LoadScene(SceneName.Multiplayer.ToString());
                }
                
            }

        }
        public IEnumerator wait()
        {
            yield return new WaitForSeconds(1f);
            if (!PhotonNetwork.IsConnected)
            {
                SceneManager.LoadScene(SceneName.Multiplayer.ToString());
            }
            else
            {
                StartCoroutine(wait());
            }
        }

    }
}


using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RedBall
{
    public class MultiplayerController : MonoBehaviourPunCallbacks
    {
        [Header("Login Panel")]
        public GameObject loginPanel;
        public InputField playerName;

        [Header("Selection Panel")]
        public GameObject selectionPanel;

        [Header("CreateRoom Panel")]
        public GameObject createRoomPanel;
        public InputField roomNameInput;

        [Header("JoinRoom Panel")]
        public GameObject joinRoomPanel;
        public InputField joinRoomName;

        [Header("InsideRoom Panel")]
        public GameObject insideRoomPanel;
        public Text waitingStatus;
        public Button startGame;
        #region  UNITY
        private void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            playerName.text = "Player " + Random.Range(1000, 10000);
            SetActivePanel(loginPanel.name);
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (PhotonNetwork.CurrentRoom != null)
            {
                if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
                {
                    waitingStatus.text = "Ready to start the game";
                    startGame.interactable = true;
                }
                else
                {
                    waitingStatus.text = "waiting for an opponent";
                    startGame.interactable = false;
                }
            }            
            
            if (PhotonNetwork.IsMasterClient)
            {
                startGame.gameObject.SetActive(true);
            }
            else
            {
                startGame.gameObject.SetActive(false);
            }
        }
        #endregion

        #region UI Methods
        public void OnClickLogin()
        {
            string name = playerName.text;
            if (!name.Equals(""))
            {
                PhotonNetwork.NickName = name;
                PhotonNetwork.ConnectUsingSettings();
            }
        }
        /// <summary>
        /// SetActivePannel method activate the required pannel
        /// </summary>
        /// <param name="name"> name decides which pannel is to be active</param>
        public void SetActivePanel(string name)
        {
            loginPanel.SetActive(name.Equals(loginPanel.name));
            selectionPanel.SetActive(name.Equals(selectionPanel.name));
            createRoomPanel.SetActive(name.Equals(createRoomPanel.name));
            joinRoomPanel.SetActive(name.Equals(joinRoomPanel.name));
            insideRoomPanel.SetActive(name.Equals(insideRoomPanel.name));
        }
        public void OnClickExit()
        {
            PhotonNetwork.Disconnect();
            SceneManager.LoadScene(SceneName.MainMenu.ToString());
        }
        public void OnLeaveGameButtonClicked()
        {
            PhotonNetwork.LeaveRoom();
        }
        public void OnCreateRoomButtonClicked()
        {
            string roomName = roomNameInput.text;
            roomName = (roomName.Equals(string.Empty)) ? "Room " + Random.Range(1000, 10000) : roomName;
            byte maxPlayers = 2;
            RoomOptions options = new RoomOptions { MaxPlayers = maxPlayers};
            PhotonNetwork.CreateRoom(roomName, options, null);
        }
        public void OnJoinRoomButtonClicked()
        {
            SetActivePanel(joinRoomPanel.name);
            string roomName = joinRoomName.text;
            PhotonNetwork.JoinRoom(roomName);
        }
        public void OnClickStartGame()
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.LoadLevel(SceneName.Game.ToString());
        }
        #endregion

        #region Photon CallBacks
        public override void OnConnectedToMaster()
        {
            SetActivePanel(selectionPanel.name);
        }
        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            SetActivePanel(selectionPanel.name);
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            SetActivePanel(selectionPanel.name);
        }
        public override void OnJoinedRoom()
        {
            SetActivePanel(insideRoomPanel.name);
        }
        #endregion

    }

}

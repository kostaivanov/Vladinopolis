using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameSettings gameSettings;

    // Start is called before the first frame update
    void Start()
    {
        print("Connecting to server.");
        PhotonNetwork.NickName = MasterManager.GameSettings.Nickname;
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        print($"{PhotonNetwork.LocalPlayer.NickName} has connected to the server.");
    }

    public override void OnJoinedLobby()
    {
        //we load lobby scene here

        SceneManager.LoadScene("Lobby");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnected from server for reason " + cause.ToString());
    }
}

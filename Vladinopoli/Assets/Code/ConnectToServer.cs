using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    //[SerializeField] private CanvasManager canvasManager;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        //PhotonNetwork.GameVersion = "0.0.1";
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        print("Connected to server.");

    }

    public override void OnJoinedLobby()
    {
        //we load lobby scene here
        //canvasManager.SwitchCanvas(CanvasType.Lobby);
        SceneManager.LoadScene("Lobby");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnected from server for reason " + cause.ToString());
    }
}

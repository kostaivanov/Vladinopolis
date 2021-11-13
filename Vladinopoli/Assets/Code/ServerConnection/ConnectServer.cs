using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ConnectServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        print("Connecting to server.");
        PhotonNetwork.NickName = MasterManager.GameSettings.Nickname;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon.", this);
        Debug.Log("My nickname is " + PhotonNetwork.LocalPlayer.NickName, this);
        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Failed to connect to Photon:  " + cause.ToString(), this);
    }
}

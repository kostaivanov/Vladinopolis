using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public Text createRoomInput;
    //public InputField joinInput;

    //public void CreateRoom()
    //{
    //    PhotonNetwork.CreateRoom(createRoomInput.text);
    //}

    //public void JoinRoom()
    //{
    //    PhotonNetwork.JoinRoom(joinInput.text);
    //}

    public override void OnJoinedRoom()
    {
        //PhotonNetwork.LoadLevel("Game");
    }

    public void OnClick_CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 10;
        PhotonNetwork.JoinOrCreateRoom(createRoomInput.text, options, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created room successfully!");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("Room creation failed!");
    }
}

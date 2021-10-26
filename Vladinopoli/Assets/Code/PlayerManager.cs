using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;

public class PlayerManager : MonoBehaviourPun
{
    [SerializeField] private GameObject camera;
    private GameObject makeYourChoiceObject;
    private List<GameObject> playerInGame;
    // Start is called before the first frame update
    void Start()
    {
        CameraWork cameraWork = this.gameObject.GetComponent<CameraWork>();
        playerInGame = new List<GameObject>();
        if (!photonView.IsMine)
        {
            camera.SetActive(false);
        }

        makeYourChoiceObject = GameObject.FindGameObjectWithTag("MakeYourChoiceObject");
        makeYourChoiceObject.SetActive(true);
        //if (cameraWork != null)
        //{
        //    if (photonView.IsMine)
        //    {
        //        cameraWork.OnStartFollowing();
        //    }
        //}
        //else
        //{
        //    Debug.LogError("<Color=Red><a>Missing</a></Color> CameraWork Component on playerPrefab.", this);

        //}
    }


    private void Update()
    {
        Debug.Log("number of player in the game = " + PhotonNetwork.CurrentRoom.PlayerCount);
        //if (PhotonNetwork.IsConnected)
        //{
        //    playerInGame.Add(GameObject.FindGameObjectWithTag("Player"));
        //}
    }
}

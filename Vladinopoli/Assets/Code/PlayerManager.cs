using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using System.Linq;
public class PlayerManager : MonoBehaviourPun
{
    [SerializeField] private GameObject camera;
    private GameObject makeYourChoiceObject;
    private List<string> playersInGame;


    private int currentNumber;
    private int previousNumber;
    // Start is called before the first frame update
    void Start()
    {
        CameraWork cameraWork = this.gameObject.GetComponent<CameraWork>();
        playersInGame = new List<string>();

        if (!photonView.IsMine)
        {
            camera.SetActive(false);
        }

        makeYourChoiceObject = GameObject.FindGameObjectWithTag("MakeYourChoiceObject");
        makeYourChoiceObject.SetActive(true);
        currentNumber = PhotonNetwork.CurrentRoom.PlayerCount;
        //previousNumber = currentNumber;
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
        if (currentNumber != PhotonNetwork.CurrentRoom.PlayerCount)
        {
            playersInGame.Add(StaticFunctions.instance.name);
            currentNumber = PhotonNetwork.CurrentRoom.PlayerCount;
            Debug.Log(playersInGame[0]);
        }
    }
}

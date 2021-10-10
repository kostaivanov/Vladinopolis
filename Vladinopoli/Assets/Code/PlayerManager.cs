using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;

public class PlayerManager : MonoBehaviourPun
{
    [SerializeField] private GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        CameraWork cameraWork = this.gameObject.GetComponent<CameraWork>();

        if (!photonView.IsMine)
        {
            camera.SetActive(false);
        }

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
}

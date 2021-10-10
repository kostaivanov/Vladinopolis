using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject rumenPrefab, kostaPrefab;
    public Camera camera;

    public float min_X;
    public float max_X;
    public float min_Z;
    public float max_Z;

    private void Start()
    {
        
        camera.enabled = false;
        if (StaticFunctions.instance.name == "Rumen".Trim())
        {
            //Vector3 randomPosition = new Vector3(Random.Range(min_X, max_X), 36.76f, Random.Range(min_Z, max_Z));
            Vector3 randomPosition = new Vector3(75f, 40f, 90f);
            

            GameObject rumen = PhotonNetwork.Instantiate(rumenPrefab.name, randomPosition, Quaternion.Euler(-90, 50, 180));
            //rumen.transform.localEulerAngles = new Vector3(-90f, 50f, 180f);
        }
        else
        {
            //Vector3 randomPosition = new Vector3(Random.Range(min_X, max_X), 36.76f, Random.Range(min_Z, max_Z));
            Vector3 randomPosition = new Vector3(65f, 36f, 82f);
            GameObject kosta = PhotonNetwork.Instantiate(kostaPrefab.name, randomPosition, Quaternion.Euler(-90, 45, 0));
            //kosta.transform.localEulerAngles = new Vector3(-90f, 45f, 0f);
        }
       
    }
}

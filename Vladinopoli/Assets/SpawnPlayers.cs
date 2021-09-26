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
        if (StaticFunctions.instance.name == "Rumen".Trim())
        {
            //Vector3 randomPosition = new Vector3(Random.Range(min_X, max_X), 36.76f, Random.Range(min_Z, max_Z));
            Vector3 randomPosition = new Vector3(72.14f, 43.55f, 82.12f);

            PhotonNetwork.Instantiate(rumenPrefab.name, randomPosition, Quaternion.identity);
        }
        else
        {
            //Vector3 randomPosition = new Vector3(Random.Range(min_X, max_X), 36.76f, Random.Range(min_Z, max_Z));
            Vector3 randomPosition = new Vector3(71.77f, 39.59188f, 65.06f);
            PhotonNetwork.Instantiate(kostaPrefab.name, randomPosition, Quaternion.identity);
        }
       
    }
    private void Update()
    {
        Debug.Log(StaticFunctions.instance.name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;

    public float min_X;
    public float max_X;
    public float min_Z;
    public float max_Z;

    private void Start()
    {
        Vector3 randomPosition = new Vector3(Random.Range(min_X, max_X), 36.76f, Random.Range(min_Z, max_Z));
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
    }
}

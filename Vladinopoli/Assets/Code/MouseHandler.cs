﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MouseHandler : MonoBehaviourPun
{
    // horizontal rotation speed
    public float horizontalSpeed = 1f;
    // vertical rotation speed
    public float verticalSpeed = 1f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    [SerializeField] private Camera camera;
    float mouseX = 0;
    float mouseY = 0;

    void Start()
    {
        //this.gameObject.transform.eulerAngles = new Vector3(80f, 0.0f, 0.0f);
    }
    //void OnGUI()
    //{
    //    Event e = Event.current;
    //    if (e.type == EventType.MouseMove && e.control && e.keyCode == KeyCode.shigf)
    //    {
    //        mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
    //    }
    //}

    void Update()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }

        if (Input.GetButtonDown("left shift") && Input.GetAxis("Mouse X") != 0)
        {
            mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
            Debug.Log("asdasdasdasdasda");

        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetAxis("Mouse Y") != 0)
        {
            mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;

        }

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        this.gameObject.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
    }
}

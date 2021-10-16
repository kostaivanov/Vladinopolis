using System.Collections;
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

    Quaternion originalRotation;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
            rb.freezeRotation = true;
        originalRotation = transform.localRotation;
    }

    void Update()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }

        if (Input.GetButton("Enable Debug Button 1"))
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

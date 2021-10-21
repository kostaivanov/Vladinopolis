using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float minX = -60f;
    public float maxX = 60f;

    public float sensitivity;
    public Camera cam;

    float rotY = 0f;
    float rotX = 0f;
    Quaternion originalRotation;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
            rb.freezeRotation = true;
        originalRotation = transform.localRotation;
    }

    void Update()
    {
        if (Input.GetButton("Enable Debug Button 1"))
        {
            rotY += Input.GetAxis("Mouse X") * sensitivity;
            rotX += Input.GetAxis("Mouse Y") * sensitivity;

            rotX = Mathf.Clamp(rotX, minX, maxX);
        }


        //rotAverageX = ClampAngle(rotAverageX, minimumX, maximumX);
        //rotAverageY = ClampAngle(rotAverageY, minimumY, maximumY);

        //Quaternion xQuaternion = Quaternion.AngleAxis(rotAverageX, Vector3.forward);
        //Quaternion yQuaternion = Quaternion.AngleAxis(rotAverageY, Vector3.left);

        //transform.localRotation = originalRotation * xQuaternion * yQuaternion;

        //transform.localEulerAngles = new Vector3(0, rotY, 0);
        //cam.transform.localEulerAngles = new Vector3(-rotX, 0, 0);


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Mistake happened here vvvv
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Cursor.visible && Input.GetMouseButtonDown(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        angle = angle % 360;
        if ((angle >= -360F) && (angle <= 360F))
        {
            if (angle < -360F)
            {
                angle += 360F;
            }
            if (angle > 360F)
            {
                angle -= 360F;
            }
        }
        return Mathf.Clamp(angle, min, max);
    }
}
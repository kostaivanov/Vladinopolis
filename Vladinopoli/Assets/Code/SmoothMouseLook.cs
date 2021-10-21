using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Camera-Control/Smooth Mouse Look")]
public class SmoothMouseLook : MonoBehaviour
{
    public enum RotationAxes { MouseXAndY = 0 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    [SerializeField] private float sensitivity;


    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -15F;
    public float maximumY = 15F;

    float rotationX = 0F;
    float rotationY = 0F;

    private List<float> rotArrayX = new List<float>();
    float rotAverageX = 0F;

    private List<float> rotArrayY = new List<float>();
    float rotAverageY = 0F;

    public float frameCounter = 10;

    Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.localRotation;
    }

    void Update()
    {
        if (axes == RotationAxes.MouseXAndY && Input.GetButton("Enable Debug Button 1"))
        {
            rotAverageY = 0f;
            rotAverageX = 0f;

            rotationX += Input.GetAxis("Mouse X") * sensitivity;
            rotationY += Input.GetAxis("Mouse Y") * sensitivity;

            rotArrayX.Add(rotationX);
            rotArrayY.Add(rotationY);

            if (rotArrayX.Count >= frameCounter)
            {
                rotArrayX.RemoveAt(0);
            }

            if (rotArrayY.Count >= frameCounter)
            {
                rotArrayY.RemoveAt(0);
            }

            for (int i = 0; i < rotArrayX.Count; i++)
            {
                rotAverageX += rotArrayX[i];
            }

            for (int j = 0; j < rotArrayY.Count; j++)
            {
                rotAverageY += rotArrayY[j];
            }

            rotAverageY /= rotArrayY.Count;
            rotAverageX /= rotArrayX.Count;

            rotAverageX = ClampAngle(rotAverageX, minimumX, maximumX);
            rotAverageY = ClampAngle(rotAverageY, minimumY, maximumY);

            Quaternion xQuaternion = Quaternion.AngleAxis(rotAverageX, Vector3.forward);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotAverageY, Vector3.left);

            transform.localRotation = originalRotation * xQuaternion * yQuaternion;
        }

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
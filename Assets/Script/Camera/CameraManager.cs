using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private float yaw;
    private float pitch;

    private float zoomSpeed = 0.2f;
    private float translateSpeed = 0.05f;
    private float rotationSpeed = 5.0f;

    private bool isSceneLoaded = false;

    private void Start()
    {
        yaw = transform.eulerAngles.y;
        pitch = transform.eulerAngles.x;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
            Camera.main.fieldOfView -= zoomSpeed;
        if (Input.GetKey(KeyCode.E))
            Camera.main.fieldOfView += zoomSpeed;
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 20, 70);

        if (Input.GetKey(KeyCode.W))
            Camera.main.transform.Translate(Vector3.forward * translateSpeed);
        else if (Input.GetKey(KeyCode.S))
            Camera.main.transform.Translate(Vector3.back * translateSpeed);
        else if (Input.GetKey(KeyCode.A))
            Camera.main.transform.Translate(Vector3.left * translateSpeed);
        else if (Input.GetKey(KeyCode.D))
            Camera.main.transform.Translate(Vector3.right * translateSpeed);

        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;
        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -80f, 80f);
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}

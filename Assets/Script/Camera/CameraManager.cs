using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    private float translateSpeed = 0.01f;
    private float zoomSpeed = 0.3f;
    private float rotationSpeed = 0.6f;



    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            float y = Camera.main.transform.position.y;
            Camera.main.transform.Translate(Vector3.forward * translateSpeed * Camera.main.fieldOfView * 1.4f);
            Vector3 newPosition = Camera.main.transform.position;
            newPosition.y = y;
            Camera.main.transform.position = newPosition;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            float y = Camera.main.transform.position.y;
            Camera.main.transform.Translate(Vector3.back * translateSpeed * Camera.main.fieldOfView * 1.4f);
            Vector3 newPosition = Camera.main.transform.position;
            newPosition.y = y;
            Camera.main.transform.position = newPosition;
        }
        else if (Input.GetKey(KeyCode.A))
            Camera.main.transform.Translate(Vector3.left * translateSpeed * Camera.main.fieldOfView);
        else if (Input.GetKey(KeyCode.D))
            Camera.main.transform.Translate(Vector3.right * translateSpeed * Camera.main.fieldOfView);

        if (Input.GetKey(KeyCode.Z))
        {
            if (Input.GetKey(KeyCode.LeftShift))
                Camera.main.fieldOfView += zoomSpeed;
            else
                Camera.main.fieldOfView -= zoomSpeed;
        }
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 2, 90);

        if (Input.GetKey(KeyCode.Q))
            Camera.main.transform.Rotate(Vector3.up, -rotationSpeed, Space.World);
        if (Input.GetKey(KeyCode.E))
            Camera.main.transform.Rotate(Vector3.up, rotationSpeed, Space.World);
    }
}

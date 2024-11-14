using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public float translateSpeed = 0.05f;
    public float zoomSpeed = 0.1f;
    public float rotationSpeed = 0.1f;



    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            float y = Camera.main.transform.position.y;
            Camera.main.transform.Translate(Vector3.forward * translateSpeed * 1.4f);
            Vector3 newPosition = Camera.main.transform.position;
            newPosition.y = y;
            Camera.main.transform.position = newPosition;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            float y = Camera.main.transform.position.y;
            Camera.main.transform.Translate(Vector3.back * translateSpeed * 1.4f);
            Vector3 newPosition = Camera.main.transform.position;
            newPosition.y = y;
            Camera.main.transform.position = newPosition;
        }
        else if (Input.GetKey(KeyCode.A))
            Camera.main.transform.Translate(Vector3.left * translateSpeed);
        else if (Input.GetKey(KeyCode.D))
            Camera.main.transform.Translate(Vector3.right * translateSpeed);

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

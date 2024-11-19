using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiberalMode : GameMode_StateMachine
{
    private GameObject selectedGameObject;

    private Vector3 mouse_position;
    private Vector3 offset, mouseStartPos;
    private float depth;



    public override void HandleInput()
    {
        base.HandleInput();
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000f, ~LayerMask.GetMask("Environment")))
            {
                selectedGameObject = hit.collider.gameObject;
                depth = hit.distance;
                mouseStartPos = ray.origin + ray.direction * depth;
                offset = selectedGameObject.transform.position - mouseStartPos;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            selectedGameObject = null;
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000f, ~LayerMask.GetMask("Environment")))
            {
                if (hit.collider.gameObject.GetComponent<Function>() != null)
                {
                    hit.collider.gameObject.GetComponent<Function>().enabled = hit.collider.gameObject.GetComponent<Function>().enabled ? false : true;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gameMode.gameMode = GetComponent<CreativeMode>();
            gameMode.gameMode.enabled = true;
            this.enabled = false;
        }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (selectedGameObject != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                selectedGameObject.transform.position = ray.origin + ray.direction * depth + offset;
            }
        }
    }
}
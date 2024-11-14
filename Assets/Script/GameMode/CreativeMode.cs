using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreativeMode : GameMode_StateMachine
{
    public override void HandleInput(KeyCode keyCode, GameObject objectPrefab, Vector3 position)
    {
        if (keyCode == KeyCode.Mouse0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(objectPrefab, position, Quaternion.identity);
            }
        }
        else if (keyCode == KeyCode.Mouse1)
        {
            print("Mouse1");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000000f, ~LayerMask.GetMask("Environment")))
            {
                print("Destroy " + hit.collider.gameObject.name);
                Destroy(hit.collider.gameObject);
            }
        }
    }
}

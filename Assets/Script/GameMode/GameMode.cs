using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public GameMode_StateMachine gameMode;

    public new Camera camera;
    public GameObject objectPrefab;
    public GameObject objectPreview;



    private void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            objectPreview = Instantiate(objectPreview, hit.point * 0.8f + camera.transform.position * 0.2f, Quaternion.identity);
        }
    }
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            objectPreview.transform.position = hit.point * 0.8f + camera.transform.position * 0.2f;
        }

        if (Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in PossibleKeyCode)
            {
                if (Input.GetKeyDown(keyCode))
                {
                    gameMode.HandleInput(keyCode, objectPrefab, objectPreview.transform.position);
                }
            }
        }
    }
    private KeyCode[] PossibleKeyCode = new KeyCode[]
    {
        KeyCode.Mouse0,
        KeyCode.Mouse1
    };
}
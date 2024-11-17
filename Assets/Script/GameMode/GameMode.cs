using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameMode : MonoBehaviour
{
    public GameMode_StateMachine gameMode;
    


    private void Start()
    {
        gameMode = GetComponent<CreativeMode>();
        gameMode.enabled = true;
    }
    private void Update()
    {
        if (Input.anyKeyDown || Input.GetAxis("Mouse ScrollWheel") != 0 || Input.GetMouseButtonUp(0))
        {
            gameMode.HandleInput();
        }
    }
}
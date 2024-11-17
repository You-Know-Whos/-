using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode_StateMachine : MonoBehaviour
{
    protected GameMode gameMode;
    protected float timeScale = 1;



    protected virtual void Start()
    {
        gameMode = GetComponent<GameMode>();
    }
    public virtual void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = Time.timeScale == 0 ? timeScale : 0;
        }
        if (Input.GetKeyDown(KeyCode.Tab) && Time.timeScale != 0)
        {
            Time.timeScale = Time.timeScale == 1 ? 0.1f : 1;
            timeScale = Time.timeScale;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Physics.gravity = Physics.gravity == new Vector3(0, -9.8f, 0) ? new Vector3(0, 9.8f, 0) : new Vector3(0, -9.8f, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode_StateMachine : MonoBehaviour
{
    public virtual void HandleInput(KeyCode keyCode, GameObject objectPrefab, Vector3 position) { }
}

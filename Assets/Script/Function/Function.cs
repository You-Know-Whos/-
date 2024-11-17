using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function : MonoBehaviour
{
    protected float time;
    protected float timeGo;



    protected virtual void OnEnable()
    {
        if (GetComponent<Rigidbody>().isKinematic)
        {
            this.enabled = false;
        }
        time = 0;
        timeGo = Time.deltaTime;
    }
    protected virtual void Update()
    {
        time += Time.deltaTime;
        if (time >= timeGo)
        {
            Func();
            timeGo += Time.deltaTime;
        }
    }
    protected virtual void Func() { }
}
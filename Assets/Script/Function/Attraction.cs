using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : Function
{
    private Vector3 boxSize = new Vector3(5.0f, 5.0f, 5.0f);
    private float force = 1f;



    protected override void Func()
    {
        Vector3 position = transform.position;
        Collider[] surroundingObjects = Physics.OverlapBox(position, boxSize, Quaternion.identity, ~LayerMask.GetMask("Environment"));//ÅÅ³ý»·¾³µÄÍ¼²ã
        foreach (Collider col in surroundingObjects)
        {
            col.GetComponent<Rigidbody>().AddForce((position - col.transform.position) * force);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    private Rigidbody rb;

    public Vector3 boxSize = new Vector3(5.0f, 5.0f, 5.0f);
    public float force = 1f;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Attraction();
    }
    private void Attraction()
    {    
        Vector3 position = transform.position;
        Collider[] surroundingObjects = Physics.OverlapBox(position, boxSize, Quaternion.identity, ~LayerMask.GetMask("Environment"));//排除环境的图层
        foreach (Collider col in surroundingObjects)
        {
            col.GetComponent<Rigidbody>().AddForce((position - col.transform.position) * force);
        }
    }
    private void Repulsion()
    {
        Vector3 position = transform.position;
        Collider[] surroundingObjects = Physics.OverlapBox(position, boxSize, Quaternion.identity, ~LayerMask.GetMask("Environment"));//排除环境的图层
        foreach (Collider col in surroundingObjects)
        {
            col.GetComponent<Rigidbody>().AddForce(-(position - col.transform.position) * force);
        }
    }
}
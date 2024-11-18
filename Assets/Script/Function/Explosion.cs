using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Explosion : Function
{
    private Vector3 boxSize = new Vector3(5.0f, 5.0f, 5.0f);
    private float force = 10f;
    private float explodeDelay = 5f;
    private float boomTime;
    private float timeFlash;
    private Material boomDefault;
    public Material boomFlash;



    protected override void OnEnable()
    {
        if (GetComponent<Rigidbody>().isKinematic)
        {
            this.enabled = false;
        }
        boomTime = 0;
        timeFlash = 1f;
    }
    private void Start()
    {
        boomDefault = GetComponent<Renderer>().material;
    }
    protected override void Update()
    {
        boomTime += Time.deltaTime;
        if (boomTime > timeFlash)
        {
            GetComponent<Renderer>().material = GetComponent<Renderer>().material == boomDefault ? boomFlash : boomDefault;
            timeFlash = Mathf.Lerp(boomTime, explodeDelay, 0.2f);
        }
        if (boomTime > explodeDelay)
        {
            Func();
        }
    }
    protected override void Func()
    {
        Vector3 position = transform.position;
        Collider[] surroundingObjects = Physics.OverlapBox(position, boxSize, Quaternion.identity, ~LayerMask.GetMask("Environment"));//ÅÅ³ý»·¾³µÄÍ¼²ã
        foreach (Collider col in surroundingObjects)
        {
            col.GetComponent<Rigidbody>().AddForce((col.transform.position - position) * force, ForceMode.Impulse);
        }
        Destroy(gameObject);
    }
}

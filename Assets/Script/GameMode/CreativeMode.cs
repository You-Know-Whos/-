using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreativeMode : GameMode_StateMachine
{
    public new Camera camera;
    private GameObject objectPreview;
    private LineRenderer line;
    public float transparency = 0.3f;

    public List<GameObject> objectPrefabs;
    public List<GameObject> objectPreviews;
    public int index = 0;



    private void Awake()
    {
        foreach (GameObject pf in objectPrefabs)
        {
            GameObject prefab = Instantiate(pf);
            prefab.GetComponent<Rigidbody>().isKinematic = true;
            prefab.GetComponent<Collider>().enabled = false;
            Color color = prefab.GetComponent<Renderer>().material.color;
            prefab.GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, transparency);
            prefab.GetComponent<Renderer>().receiveShadows = false;
            line = prefab.GetComponent<LineRenderer>();
            line.positionCount = 2;
            line.startWidth = 0.1f;
            line.endWidth = 0.1f;
            line.material.color = new Color(1f, 1f, 1f, transparency);
            prefab.transform.SetParent(transform);
            prefab.SetActive(false);
            objectPreviews.Add(prefab);
        }
    }
    private void OnEnable()
    {
        SetObjectPreview();
    }
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            objectPreview.transform.position = hit.point * 0.8f + camera.transform.position * 0.2f;
        }
        if (Physics.Raycast(objectPreview.transform.position, Vector3.down, out hit))
        {
            line.SetPosition(0, objectPreview.transform.position);
            line.SetPosition(1, hit.point);
        }
    }
    private void OnDisable()
    {
        objectPreview.SetActive(false);
    }
    public override void HandleInput()
    {
        base.HandleInput();
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(objectPrefabs[index], objectPreview.transform.position, Quaternion.identity);
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000f, ~LayerMask.GetMask("Environment")))
            {
                Destroy(hit.collider.gameObject);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gameMode.gameMode = GetComponent<LiberalMode>();
            gameMode.gameMode.enabled = true;
            this.enabled = false;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll > 0)
            {
                if (index < objectPreviews.Count - 1)
                    index++;
                else
                    index = 0;
            }
            else
            {
                if (index > 0)
                    index--;
                else
                    index = objectPreviews.Count - 1;
            }
            SetObjectPreview();
        }
    }
    private void SetObjectPreview()
    {
        if (objectPreview != null)
        {
            objectPreview.SetActive(false);
        }
        objectPreview = objectPreviews[index];
        objectPreview.SetActive(true);
        line = objectPreview.GetComponent<LineRenderer>();
    }
}

//public GameObject objectPreviewPrefab;
//private void OnEnable()
//{
//    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//    RaycastHit hit;
//    if (Physics.Raycast(ray, out hit))
//    {
//        objectPreview = Instantiate(objectPreviewPrefab, hit.point * 0.8f + camera.transform.position * 0.2f, Quaternion.identity);
//    }
//    objectPreview.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 0.5f);
//    objectPreview.transform.Find("Line").GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 0.5f);
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class CreativeMode : GameMode_StateMachine
{
    public new Camera camera;
    public List<GameObject> objectPrefabs;

    private GameObject objectPreview = null;
    private LineRenderer line;
    private float transparency = 0.3f;
    private float depth = 0.8f;
    private List<GameObject> objectPreviews = new List<GameObject>();
    private int index = 0;
    private Dictionary<string, Image> opUIDictionary = new Dictionary<string, Image>();



    private void Awake()
    {
        foreach (GameObject pf in objectPrefabs)
        {
            GameObject prefab = Instantiate(pf, transform);
            prefab.name = pf.name;
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
            objectPreviews.Add(prefab);
            prefab.SetActive(false);

            GameObject objectPreviewUI = new GameObject(pf.name);
            objectPreviewUI.transform.SetParent(GameObject.Find("Canvas/ObjectPreviewUI").transform);
            objectPreviewUI.AddComponent<Image>();
            ObjectPreviewUI.Instance.AddImage(objectPreviewUI);
            objectPreviewUI.GetComponent<Image>().color = new Color(1, 1, 1, transparency);
            opUIDictionary.Add(pf.name, objectPreviewUI.GetComponent<Image>());

            CreativeMode_ObjectPool.Instance.AddObjectPool(pf);
            new GameObject(pf.name).transform.SetParent(CreativeMode_ObjectPool.Instance.objects.transform);
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
            objectPreview.transform.position = hit.point * depth + camera.transform.position * (1 - depth);
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
                GameObject obj = CreativeMode_ObjectPool.Instance.objectPools[objectPrefabs[index].name].Get();
                obj.transform.position = objectPreview.transform.position;
                obj.transform.rotation = Quaternion.identity;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000f, ~LayerMask.GetMask("Environment")))
            {
                CreativeMode_ObjectPool.Instance.objectPools[hit.collider.gameObject.name].Release(hit.collider.gameObject);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gameMode.gameMode = GetComponent<LiberalMode>();
            gameMode.gameMode.enabled = true;
            this.enabled = false;
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (depth < 0.995f)
                depth += 0.005f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (depth > 0.055f)
                depth -= 0.005f;
        }
    }
    private void SetObjectPreview()
    {
        if (objectPreview != null)
        {
            objectPreview.SetActive(false);
            if (opUIDictionary.TryGetValue(objectPreview.name, out Image oldImage))
            {
                oldImage.color = new Color(1, 1, 1, transparency);
            }
        }
        objectPreview = objectPreviews[index];
        objectPreview.SetActive(true);
        line = objectPreview.GetComponent<LineRenderer>();
        if (opUIDictionary.TryGetValue(objectPreview.name, out Image newImage))
        {
            newImage.color = new Color(1, 1, 1, 1);
        }
    }
}
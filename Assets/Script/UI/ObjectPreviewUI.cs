using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPreviewUI : MonoBehaviour
{
    public static ObjectPreviewUI Instance { get; private set; }

    public ObjectPreviewSO objectPreviewSO;



    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Instance = this;
            Destroy(this.gameObject);
        }
        Instance = this;
    }
    public void AddImage(GameObject objectPreviewUI)
    {
        string name = objectPreviewUI.name;
        foreach (Sprite objectPreview in objectPreviewSO.sprites)
        {
            if (objectPreview.name == name)
            {
                objectPreviewUI.GetComponent<Image>().sprite = objectPreview;
            }
        }
    }
}

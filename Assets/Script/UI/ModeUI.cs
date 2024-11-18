using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeUI : MonoBehaviour
{
    public static ModeUI Instance { get; private set; }

    private GameMode gameMode;
    private Image action;
    private Image stop;
    private Image slow;
    private Image quick;



    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Instance = this;
            Destroy(this.gameObject);
        }
        Instance = this;
    }
    private void Start()
    {
        gameMode = FindObjectOfType<GameMode>();
        action = transform.Find("Action").GetComponent<Image>();
        stop = transform.Find("Stop").GetComponent<Image>();
        slow = transform.Find("Slow").GetComponent<Image>();
        quick = transform.Find("Quick").GetComponent<Image>();
    }
    public void SetImage(float timeScale)
    {
        action.color = Time.timeScale == 0 ? new Color(1, 1, 1, 0.3f) : new Color(1, 1, 1, 1);
        stop.color = Time.timeScale == 0 ? new Color(1, 1, 1, 1) : new Color(1, 1, 1, 0.3f);
        slow.color = timeScale == 0.1f ? new Color(1, 1, 1, 1) : new Color(1, 1, 1, 0.3f);
        quick.color = timeScale == 1 ? new Color(1, 1, 1, 1) : new Color(1, 1, 1, 0.3f);
    }
}

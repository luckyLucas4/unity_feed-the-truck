using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Text uiText;
    [SerializeField] private float mainTimer;

    private float timer;

    void Start()
    {
        timer = 0.0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        uiText.text = "Time: " + timer.ToString("F");
    }
}

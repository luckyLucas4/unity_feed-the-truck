using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaWallManager : MonoBehaviour
{
    private SpriteRenderer alphaWallRenderer;

    // Start is called before the first frame update
    void Start()
    {
        alphaWallRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        alphaWallRenderer.enabled = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        alphaWallRenderer.enabled = false;
    }
}

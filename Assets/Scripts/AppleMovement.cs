using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleMovement : MonoBehaviour
{
    public bool isFalling = false;
    public bool isWiggling = false;
    public int compostValue = 5;
    public int collectValue = 1;

    private float wiggleDistance = 0.1f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.Translate(new Vector3(1, 0, 0) * Random.Range(-0.5f,0.5f));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AppleDestroyer"))
        { 
            GetComponentInParent<TreeManagement>().compostScript.AddCompost(compostValue);
            Destroy(gameObject);
        }
    }

    public void Fall(float timeBeforeWiggle, float wiggleTime)
    {
        isFalling = true;
        isWiggling = true;
        StartCoroutine(Falling(timeBeforeWiggle, wiggleTime));
    }

    private IEnumerator Falling(float timeBeforeWiggle, float wiggleTime)
    {
        yield return new WaitForSeconds(timeBeforeWiggle);
        StartCoroutine(WiggleLoop());

        yield return new WaitForSeconds(wiggleTime);
        isWiggling = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private IEnumerator WiggleLoop()
    {
        int wiggleDir = 1;
        while (isWiggling)
        {
            transform.Translate(transform.right * wiggleDistance * wiggleDir);
            wiggleDir = -wiggleDir;
            yield return new WaitForSeconds(0.1f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirTreeManagement : MonoBehaviour
{
    public int airTreeCost = 5;

    public Sprite airTreeSprite0;
    public Sprite airTreeSprite1;

    public SmogManagement smogScript;

    private bool treeGrown;
    private SpriteRenderer airTreeRenderer;

    // Start is called before the first frame update
    void Start()
    {
        airTreeRenderer = GetComponent<SpriteRenderer>();
        treeGrown = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int FeedingairTree(int apples)
    {
        if ((apples >= airTreeCost) && (treeGrown == false))
        {
            treeGrown = true;
            airTreeRenderer.sprite = airTreeSprite1;
            smogScript.SmogTranslate();
            return airTreeCost;
        }
        else
        {
            return 0;
        }
    }
}

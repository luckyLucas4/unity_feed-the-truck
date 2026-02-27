using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManagement : MonoBehaviour
{
    public GameObject apple;
    public float appleSpawnRate = 6;
    public float appleWaitTime = 5;
    public float appleWiggleTime = 3;
    public int appleCollectValue = 1;
    public int appleCompostValue = 5;
    public float modifierValue = 2;
    public float modifierSpawnRate = 2;
    public float modifierLevelUpCost = 2;
    public int levelUpCost = 3;
    public int level = 2;
    public CompostManagement compostScript;
    public Sprite[] treeSprites = new Sprite[5]; 

    [HideInInspector]
    public List<AppleMovement> apples;

    private SpriteRenderer spriteRenderer;
    private int prevLevel;
    private float appleTimer;
    // Start is called before the first frame update
    void Start()
    {
        prevLevel = level;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        appleTimer += Time.deltaTime;
        if (appleTimer > appleSpawnRate)
        {
            CreateApple();
            appleTimer = 0;
        }

        if(prevLevel != level && (1 <= level && level <= 5))
        {
            spriteRenderer.sprite = treeSprites[level - 1];
            prevLevel = level;
        }
    }

    private void CreateApple()
    {   
        AppleMovement newApple = Instantiate(apple, transform).GetComponent<AppleMovement>();
        apples.Add(newApple);
        newApple.compostValue = appleCompostValue;
        newApple.collectValue = appleCollectValue;
        newApple.Fall(appleWaitTime, appleWiggleTime);
    }

    public int LevelUp(int apples)
    {
        if (apples >= levelUpCost && level < 5)
        {
            level++;
            appleCollectValue = System.Convert.ToInt32(appleCollectValue * modifierValue);
            appleCompostValue = System.Convert.ToInt32(appleCompostValue * modifierValue);
            appleSpawnRate = appleSpawnRate * 1/modifierSpawnRate;
            levelUpCost = System.Convert.ToInt32(levelUpCost * modifierLevelUpCost);
            return levelUpCost;
        }
        else
            return 0;
    }
}

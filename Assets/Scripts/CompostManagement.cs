using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompostManagement : MonoBehaviour
{
    public float compostOnPile = 0;
    public Sprite[] compostSprites = new Sprite[5];

    public float oldCompostValue;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        oldCompostValue = compostOnPile;
    }
    void Update()
    {
        if (compostOnPile > 100)
            spriteRenderer.sprite = compostSprites[4];

        if (compostOnPile > 60)
            spriteRenderer.sprite = compostSprites[3];

        else if (compostOnPile > 35)
            spriteRenderer.sprite = compostSprites[2];

        else if( compostOnPile > 10)
            spriteRenderer.sprite = compostSprites[1];

        else
            spriteRenderer.sprite = compostSprites[0];

    }

    // Update is called once per frame
    public void AddCompost(int amount)
    {
        compostOnPile += amount;
    }

    public int RemoveCompost()
    {
        int toReturn = System.Convert.ToInt32(compostOnPile);
        compostOnPile = 0;
        return toReturn;
    }
}

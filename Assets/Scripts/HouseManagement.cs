using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class HouseManagement : MonoBehaviour
{
    public int houseLevel = 0;
    public float cps = 2;
    public CompostManagement compostScript;
    public AudioClip sawingClip;
    public AudioClip hammeringClip;

    public Sprite[] houseSprites = new Sprite[5];

    public NurseryManagement nurseryScript;

    private float waitingCompost = 0;
    private int oldHouseLevel;
    private SpriteRenderer houseRenderer;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        houseRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        oldHouseLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        waitingCompost += cps * Time.deltaTime;
        if(waitingCompost > 5)
        {
            compostScript.AddCompost(System.Convert.ToInt32(waitingCompost));
            waitingCompost = 0;
        }

        houseLevel = nurseryScript.HouseLevel(); 

        if (houseLevel != oldHouseLevel)
        {
            oldHouseLevel = houseLevel;
            StartCoroutine(LevelUpSound());
        }
    }

    private IEnumerator LevelUpSound()
    {
        yield return new WaitForSeconds(2);
        audioSource.clip = sawingClip;
        audioSource.Play();
        yield return new WaitForSeconds(1);
        audioSource.clip = hammeringClip;
        audioSource.Play();
        yield return new WaitForSeconds(0.5f);
        houseRenderer.sprite = houseSprites[houseLevel];
        yield return new WaitForSeconds(0.5f);
        audioSource.Stop();
    }
}

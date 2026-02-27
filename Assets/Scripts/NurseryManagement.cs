using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class NurseryManagement : MonoBehaviour
{
    public int applesCost = 5;
    public int maxLevel = 4;
    public int houseLevelVal;
    public HouseManagement houseManagement;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        houseLevelVal = 0;
        audioSource = GetComponent<AudioSource>();
    }

    public int Feedinga(int apples)
    {
        if ((apples >= applesCost) && (houseLevelVal < maxLevel))
        {
            WaitBeforeLevelUp();
            return applesCost;
        }
        else
        {
            return 0;
        }
    }
    private void WaitBeforeLevelUp()
    {
        audioSource.Play();
        houseLevelVal++;
        applesCost = 5 * houseLevelVal;
        houseManagement.cps *= 2;
    }
    public int HouseLevel()
    {
        return houseLevelVal;
    }
}

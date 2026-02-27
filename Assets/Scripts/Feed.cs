using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Feed : MonoBehaviour
{
    public TruckMovement truckScript;
    public NurseryManagement nurseryScript;
    public int compost;
    public int apples;
    public Text compostText;
    public Text popUpText;

    void Update()
    {
        compostText.text = "Compost: " + compost.ToString() + "\nApples: " + apples.ToString();
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // payment control

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(other.GetComponent<TruckMovement>())
                compost -= truckScript.Feeding(compost);
            if (other.GetComponent<NurseryManagement>())
                apples -= nurseryScript.Feedinga(apples);
            if (other.GetComponent<AirTreeManagement>())
                apples -= other.gameObject.GetComponent<AirTreeManagement>().FeedingairTree(apples);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (other.GetComponent<TruckMovement>())
                compost -= truckScript.Feedingslow(compost);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //pop up control

        if (other.GetComponent<TruckMovement>())
            popUpText.text = "Slow Truck 'Q': " + other.GetComponent<TruckMovement>().compostSlowCost.ToString()
                + " or Reverse Truck 'E': " + other.GetComponent<TruckMovement>().compostCost.ToString() + " compost";

        if (other.GetComponent<NurseryManagement>())
            popUpText.text = "Get Baby 'E': " + other.GetComponent<NurseryManagement>().applesCost.ToString() + " apples";

        if (other.GetComponent<TreeManagement>())
            popUpText.text = "Upgrade Tree 'E': " + other.GetComponent<TreeManagement>().levelUpCost.ToString() + " compost";

        if (other.GetComponent<AirTreeManagement>())
            popUpText.text = "Push back smog 'E': " + other.GetComponent<AirTreeManagement>().airTreeCost.ToString() + " apples";
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        popUpText.text = " ";
    }
}

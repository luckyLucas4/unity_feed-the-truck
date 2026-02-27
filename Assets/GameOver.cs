using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text gameOverText;

    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<TruckMovement>())
        {
            StartCoroutine(GameOverFunction());
        }
    }

    private IEnumerator GameOverFunction()
    {
        audioSource.Play();
        gameOverText.GetComponent<Text>().enabled = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}

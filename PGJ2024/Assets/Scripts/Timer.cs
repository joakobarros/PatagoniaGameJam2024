using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float elapsedTime;
    private bool endGame = false;
    private AudioSource stinger;
    public AudioSource musicBox;

    private void Start() 
    {
        stinger = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime <= 0)
        {
            elapsedTime = 0;
            
            if (!endGame)
            {
                endGame = true;
                StartCoroutine(FinalJuego());
            }
            
        }

        if (elapsedTime > 0)
        {
            elapsedTime -= Time.deltaTime;
        }

        int minutos = Mathf.FloorToInt(elapsedTime / 60);
        int segundos = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}",minutos,segundos);
    }

    IEnumerator FinalJuego()
    {
        musicBox.Stop();
        stinger.Play();
        GameObject[] calamares = GameObject.FindGameObjectsWithTag("Calamares"); 
        Record.Instance.SetCalamares(calamares.Length);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Victoria");
    }
}

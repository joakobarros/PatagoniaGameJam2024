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
    private bool ultimosDiez = false;
    public AudioSource stinger;
    public AudioSource musicBox;
    public AudioSource ultimosSegs;


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

        if (elapsedTime <= 10 && !ultimosDiez)
        {
            ultimosDiez = true;
            ultimosSegs.Play();
            Debug.Log("sape");
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
        ultimosSegs.Stop();
        stinger.Play();
        GameObject[] calamares = GameObject.FindGameObjectsWithTag("Calamares"); 
        Record.Instance.SetCalamares(calamares.Length);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Victoria");
    }
}

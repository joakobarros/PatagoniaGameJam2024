using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private string nombreEscena;
    public AudioSource audioSource;

    public void Menu()
    {
        nombreEscena = "Menu";
        StartCoroutine(PasoEscena());
    }

    public void Creditos()
    {
        nombreEscena = "Creditos";
        StartCoroutine(PasoEscena());
    }

    public void Jugar()
    {
        nombreEscena = "Nivel1";
        StartCoroutine(PasoEscena());
    }

    public void Controles()
    {
        nombreEscena = "Controles";
        StartCoroutine(PasoEscena());
    }

    IEnumerator PasoEscena()
    {   
        audioSource.Play();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nombreEscena);
    }
}

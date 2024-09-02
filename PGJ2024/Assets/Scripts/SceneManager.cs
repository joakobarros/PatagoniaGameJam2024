using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private string nombreEscena;

    public void Menu()
    {
        nombreEscena = "Menu";
        StartCoroutine(PasoEscena());
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void Jugar()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void Controles()
    {
        SceneManager.LoadScene("Controles");
    }

    IEnumerator PasoEscena()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nombreEscena);
    }
}

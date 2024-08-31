using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void Jugar()
    {
        SceneManager.LoadScene("Nivel1");
    }
}

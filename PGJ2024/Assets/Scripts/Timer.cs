using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float elapsedTime;

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime <= 0)
        {
            SceneManager.LoadScene("Victoria");
        }
        elapsedTime -= Time.deltaTime;
        int minutos = Mathf.FloorToInt(elapsedTime / 60);
        int segundos = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}",minutos,segundos);
    }
}

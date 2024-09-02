using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject barquito;
    public Transform puntoSpawn;
    public float tiempoAparición;
    private float tiempoActual;

    private void Start() 
    {
        tiempoActual = tiempoAparición;    
    }

    // Update is called once per frame
    void Update()
    {
        tiempoActual -= Time.deltaTime;

        if (tiempoActual <= 0)
        {
            Instantiate(barquito, puntoSpawn);
            tiempoActual = tiempoAparición;
        }
    }
}

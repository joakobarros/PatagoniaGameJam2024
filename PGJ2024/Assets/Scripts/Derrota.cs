using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Derrota : MonoBehaviour
{
    [SerializeField] private GameObject[] calamares;
    void Start()
    {
        calamares = GameObject.FindGameObjectsWithTag("Calamares");    
    }

    // Update is called once per frame
    void Update()
    {
        if (calamares.Length <= 0)
        {
            Record.Instance.SetCalamares(calamares.Length);
            SceneManager.LoadScene("Derrota");
        }
    }

    public void AdiosCalamari()
    {
        calamares = GameObject.FindGameObjectsWithTag("Calamares"); 
    }
}

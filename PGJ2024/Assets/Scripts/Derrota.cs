using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Derrota : MonoBehaviour
{
    [SerializeField] private GameObject[] calamares;
    private bool derrota = false;
    private AudioSource stinger;
    public AudioSource musicBox;

    void Start()
    {
        stinger = GetComponent<AudioSource>();
        calamares = GameObject.FindGameObjectsWithTag("Calamares");    
    }

    // Update is called once per frame
    void Update()
    {
        if (calamares.Length <= 0 && !derrota)
        {
            derrota = true;
            StartCoroutine(FinJuego());  
        }
    }

    public void AdiosCalamari()
    {
        calamares = GameObject.FindGameObjectsWithTag("Calamares"); 
    }

    IEnumerator FinJuego()
    {
        musicBox.Stop();
        stinger.Play();
        Record.Instance.SetCalamares(calamares.Length);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Derrota");
    }
}

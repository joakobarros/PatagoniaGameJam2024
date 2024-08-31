using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calamares : MonoBehaviour
{
    public int cantidad = 15;
    public bool pescando;
    public bool captura;
    public int pescadores;
    public float tiempo = 15f;

    private void Update() 
    {
        if (cantidad <= 0)
        {
            Destroy(gameObject);
        }  

        if (pescando && !captura)
        {
            StartCoroutine(Pescar());
        }     
    }

    public void Resta()
    {
        cantidad--;
    }

    public void MasPescadores()
    {
        pescadores++;
        pescando = true;
        captura = true;
    }

    IEnumerator Pescar()
    {   
        captura = true;
        yield return new WaitForSeconds(tiempo/pescadores);
        Resta();
        captura = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("ejecuta");
        if (other.CompareTag("Pesquero"))
        {
            Debug.Log("ejecuta");
            other.GetComponent<Calamares>().MasPescadores();
        }    
    }
}

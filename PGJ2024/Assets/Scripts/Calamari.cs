using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calamari : MonoBehaviour
{
    public int cantidad = 15;
    public bool pescando;
    public bool captura;
    public int pescadores;
    public float tiempo = 10f;

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
    }

    IEnumerator Pescar()
    {   
        captura = true;
        yield return new WaitForSeconds(tiempo/pescadores);
        Resta();
        captura = false;
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Pesquero"))
        {
            pescadores = 0;
            pescando = false;
        }
    }

}
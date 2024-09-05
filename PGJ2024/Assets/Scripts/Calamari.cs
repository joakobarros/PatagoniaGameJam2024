using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calamari : MonoBehaviour
{
    public int cantidad = 9;
    public bool pescando;
    public bool captura;
    public int pescadores;
    public float tiempo = 10f;
    private Derrota derrota;

    private void Start() 
    {
        derrota = GameObject.Find("Derrota").GetComponent<Derrota>();    
    }

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
        Debug.Log("pescando");
        pescadores++;
        pescando = true;
    }

    IEnumerator Pescar()
    {   
        captura = true;
        float tiempoPesca = tiempo/pescadores;
        yield return new WaitForSeconds(tiempoPesca);
        Resta();
        captura = false;
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Pesquero"))
        {
            other.GetComponent<MaquinaEstados>().Volver(false);
            pescadores = 0;
            pescando = false;
        }
    }

    private void OnDestroy() 
    {
        derrota.AdiosCalamari();    
    }

}
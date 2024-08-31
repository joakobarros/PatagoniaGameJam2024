using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Transform[] calamares;
    public Transform objetivo;
    public bool pescando = false;
    public float velocidad;
    void Start()
    {
        int pesca = Random.Range(0, 1);
        objetivo = calamares[pesca];
    }

    // Update is called once per frame
    void Update()
    {
        if (!pescando && transform.position != objetivo.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);
        }
        else
        {
            if (transform.position == objetivo.position)
            {
                pescando = true;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("ejecuta");
        if (other.CompareTag("Calamares"))
        {
            Debug.Log("ejecuta");
            other.GetComponent<Calamares>().MasPescadores();
        }    
    }

}

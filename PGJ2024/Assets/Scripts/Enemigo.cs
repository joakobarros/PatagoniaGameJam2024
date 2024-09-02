using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public PuntoPesca[] calamares;
    public Transform objetivo;
    public GameObject puntoEscape;
    private Vector3 transformPosition;
    public bool pescando = false;
    public bool escapando = false;
    public float velocidad = 5f;
    int pesca;
    public float tiempoVolver;

    public GameObject admiracion;
    public Animator animator; 
    private GameObject puntoDePesca;

    void Start()
    {
        calamares = GameObject.FindObjectsByType<PuntoPesca>(FindObjectsSortMode.None);
        //pesca = Random.Range(0, 8);
        //transformPosition = new Vector3(calamares[pesca].transform.position.x, calamares[pesca].transform.position.y, calamares[pesca].transform.position.z);
        //objetivo.position = transformPosition;
        animator = GetComponent<Animator>();
        StartCoroutine(Pescar());
    }

    // Update is called once per frame
    void Update()
    {

        /* if (!pescando && transform.position != objetivo.transform.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, objetivo.transform.position, velocidad * Time.deltaTime);
        }
        else
        {
            if (transform.position == objetivo.transform.position && calamares[pesca].name == "izquierda")
            {
                animator.SetTrigger("izquierda");
                pescando = true;
            }
            else
            {
                animator.SetTrigger("derecha");
                pescando = true;
            }


            if (transform.position == puntoEscape.transform.position && escapando)
            {
                animator.SetBool("escapando", false);
                StartCoroutine(NuevoPunto());
            }
        } */
    }

    public void Huida()
    {
        if (!escapando)
        {
            objetivo.transform.position = puntoEscape.transform.position;
            pescando = false;
            StartCoroutine(Atencion());
            animator.SetBool("escapando", true);
        }  
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Calamares"))
        {
            other.GetComponent<Calamari>().MasPescadores();
        } 
    }

    IEnumerator Atencion()
    {
        escapando = true;
        admiracion.SetActive(true);
        yield return new WaitForSeconds(2f);
        admiracion.SetActive(false);
        yield return new WaitForSeconds(4f);   
    }

    IEnumerator NuevoPunto()
    {
        Debug.Log("prueba");
        escapando = false;
        yield return new WaitForSeconds(tiempoVolver);
        pesca = Random.Range(0, 8);
        transformPosition = new Vector3(calamares[pesca].transform.position.x, calamares[pesca].transform.position.y, calamares[pesca].transform.position.z);
        objetivo.position = transformPosition;
    }

    IEnumerator Pescar()
    {
        if (puntoDePesca == null)
        {
            pesca = Random.Range(0, 7);
            puntoDePesca = calamares[pesca].gameObject;
        }

        while (Vector2.Distance(transform.position, puntoDePesca.transform.position) > 0.1)
        {
            transform.position = Vector2.MoveTowards(transform.position, puntoDePesca.transform.position, velocidad * Time.deltaTime);
        }

        Debug.Log("llegue al punto de pesca");
        yield break;
    }
}

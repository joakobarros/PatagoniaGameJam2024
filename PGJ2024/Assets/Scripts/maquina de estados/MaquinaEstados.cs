using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaEstados : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool pescando;
    public bool huyendo;
    public bool espantado;
    [SerializeField]private GameObject[] waypoints;
    [SerializeField] private Transform huida;
    [SerializeField] private int currentWaypoint;
    public GameObject admiracion;
    public Animator animator;
    private AudioSource audioSource;

    private void Start() 
    {
        waypoints = GameObject.FindGameObjectsWithTag("PuntoPesca");
        currentWaypoint = Random.Range(0, waypoints.Length);
        huida = GameObject.Find("Barconodriza").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() 
    {   
        //if (waypoints[currentWaypoint].transform.position == null)
        //{
            //waypoints = GameObject.FindGameObjectsWithTag("PuntoPesca");
            //currentWaypoint = Random.Range(0, waypoints.Length);
            //Debug.Log("Cambio direccion");
        //}

        if (!huyendo)
        {
            if (transform.position != waypoints[currentWaypoint].transform.position)
            {
                transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, speed * Time.deltaTime);
            }
            else
            {
                if (!pescando)
                {
                    Animacion();
                }
                
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, huida.position, speed * Time.deltaTime);
        }
            

        if (transform.position == huida.position)
        {
            Destroy(gameObject);
        }
          
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Calamares"))
        {
            other.GetComponent<Calamari>().MasPescadores();
        } 
    }

    public void Volver(bool asustado)
    {
        if (asustado != espantado)
        {
            StartCoroutine(Atencion());
            Record.Instance.Setpescadores();
            espantado = asustado;
            audioSource.Play();
        }
        animator.SetBool("escapando", true);
        huyendo = true;
    }

    private void Animacion()
    {
        if (waypoints[currentWaypoint].name == "izquierda")
        {
            animator.SetTrigger("izquierda");
        }
        else
        {
            animator.SetTrigger("derecha");
        }
        pescando = true;
        audioSource.Stop();
    }

    IEnumerator Atencion()
    {
        admiracion.SetActive(true);
        yield return new WaitForSeconds(2f);
        admiracion.SetActive(false);
        yield return new WaitForSeconds(4f);   
    }
}

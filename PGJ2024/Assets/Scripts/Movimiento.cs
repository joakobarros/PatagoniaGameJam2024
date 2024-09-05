using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;
    private bool aLaVista;
    public GameObject bocina;
    public int Pescadores;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // movimiento del personaje
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y =Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            bocina.SetActive(true);
            aLaVista=true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            bocina.SetActive(false);
            aLaVista=false;
        }
    }

    private void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.CompareTag("Pesquero") && aLaVista)
        {
            other.GetComponent<MaquinaEstados>().Volver(true);

        }    
    }
}

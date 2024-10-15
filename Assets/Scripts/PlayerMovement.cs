using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Velocidad de movimiento del personaje
    public float moveSpeed = 5f;

    // Referencias al Rigidbody2D y SpriteRenderer
    private Rigidbody2D rb;

    private Animator animator;

    private SpriteRenderer spriteRenderer;

    // Vector de movimiento
    private Vector2 movement;

    void Start()
    {
        // Inicializar componentes
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator.SetFloat("Speed", 0);


    }

    void Update()
    {
        // Obtener input del jugador (ejes horizontal y vertical)
        float moveX = Input.GetAxisRaw("Horizontal"); // -1 para izquierda, 1 para derecha
        float moveY = Input.GetAxisRaw("Vertical");   // -1 para abajo, 1 para arriba

        // Actualizar vector de movimiento
        movement = new Vector2(moveX, moveY).normalized;

        // Girar el sprite dependiendo de la dirección horizontal
        if (moveX != 0)
        {
            spriteRenderer.flipX = moveX < 0;  // Si se mueve a la izquierda, voltear sprite
        }
        animator.SetFloat("Speed", Mathf.Abs(moveX + moveY));
    }

    void FixedUpdate()
    {
        // Mover el jugador en FixedUpdate para mejor rendimiento con físicas
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

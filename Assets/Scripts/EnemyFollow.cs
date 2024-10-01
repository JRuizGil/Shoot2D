using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // El transform del jugador
    public float moveSpeed = 3.0f; // Velocidad de movimiento del enemigo
    public float stoppingDistance = 3.0f; // Distancia mínima a la que el enemigo se detiene

    void Update()
    {
        // Calcular la distancia al jugador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Verificar si el enemigo está a más de la distancia de parada
        if (distanceToPlayer > stoppingDistance)
        {
            // Calcular la dirección hacia el jugador
            Vector3 direction = (player.position - transform.position).normalized;

            // Mover al enemigo hacia el jugador
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}


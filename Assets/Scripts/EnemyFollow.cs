using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float moveSpeed = 3.0f; // Velocidad de movimiento del enemigo
    public float stoppingDistance = 3.0f; // Distancia m�nima a la que el enemigo se detiene respecto al jugador
    public float separationDistance = 1.5f; // Distancia m�nima entre enemigos para evitar amontonamiento
    public float retreatSpeed = 2.0f; // Velocidad de retroceso si el jugador se acerca demasiado
    private Transform targetPlayer; // Referencia al transform del jugador m�s cercano
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator.SetFloat("Speed", 0);
    }

    void Update()
    {
        // Buscar el jugador m�s cercano con el tag "Player"
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length == 0)
        {
            return; // Si no hay jugadores en la escena, no hacer nada
        }

        // Encuentra el jugador m�s cercano
        targetPlayer = GetClosestPlayer(players);

        if (targetPlayer != null)
        {
            Vector3 direction = (targetPlayer.position - transform.position).normalized;
            float distanceToPlayer = Vector3.Distance(transform.position, targetPlayer.position);

            // Separaci�n con otros enemigos
            Vector3 separationDirection = Vector3.zero;
            GameObject[] otherEnemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemy in otherEnemies)
            {
                // Ignorar al propio enemigo en la lista
                if (enemy != this.gameObject)
                {
                    float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

                    // Si est� demasiado cerca de otro enemigo
                    if (distanceToEnemy < separationDistance)
                    {
                        // Calcula la direcci�n de repulsi�n
                        Vector3 repulsionDir = (transform.position - enemy.transform.position).normalized;
                        // La fuerza de repulsi�n es inversamente proporcional a la distancia
                        separationDirection += repulsionDir / distanceToEnemy;
                    }
                }
            }

            // Ajusta la direcci�n general para incluir la separaci�n
            Vector3 finalDirection = direction;

            if (distanceToPlayer > stoppingDistance)
            {
                // Si el enemigo est� a m�s de la distancia de parada, se mueve hacia el jugador
                finalDirection += separationDirection;
                transform.position += finalDirection.normalized * moveSpeed * Time.deltaTime;
            }
            else if (distanceToPlayer < stoppingDistance)
            {
                // Si el jugador est� demasiado cerca, el enemigo retrocede
                Vector3 retreatDirection = (transform.position - targetPlayer.position).normalized;
                transform.position += (retreatDirection + separationDirection).normalized * retreatSpeed * Time.deltaTime;
                finalDirection = retreatDirection;
            }

            // Girar el sprite dependiendo de la direcci�n horizontal
            if (finalDirection.x != 0)
            {
                spriteRenderer.flipX = finalDirection.x < 0.1f;  // Si se mueve a la izquierda, voltear sprite
            }

            animator.SetFloat("Speed", Mathf.Abs(finalDirection.magnitude));
        }
    }

    // M�todo para encontrar el jugador m�s cercano
    Transform GetClosestPlayer(GameObject[] players)
    {
        Transform closestPlayer = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject player in players)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPlayer = player.transform;
            }
        }

        return closestPlayer;
    }
}

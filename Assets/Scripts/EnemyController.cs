using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Variables expuestas en el Inspector
    public GameObject[] prefab; // Array de prefabs que se van a instanciar
    public float rangoMinimo = 5f; // Distancia mínima desde el jugador
    public float rangoMaximo = 10f; // Distancia máxima desde el jugador
    public float spawnInterval = 5f; // Intervalo de tiempo entre spawns en segundos
    public Transform player; // Referencia al jugador para instanciar alrededor de él

    private void Start()
    {
        // Inicia la corrutina que spawnea enemigos cada 'spawnInterval' segundos
        StartCoroutine(SpawnEnemies());
    }

    // Corrutina para spawnear enemigos de forma periódica
    IEnumerator SpawnEnemies()
    {
        while (true) // Bucle infinito para spawnear indefinidamente
        {
            Instanciar(); // Instancia el prefab
            yield return new WaitForSeconds(spawnInterval); // Espera el intervalo antes de spawnear otro
        }
    }

    // Método para instanciar un prefab aleatorio alrededor del jugador
    public void Instanciar()
    {
        if (player == null)
        {
            Debug.LogWarning("No se ha asignado un jugador en el campo 'player'.");
            return;
        }

        // Selecciona un prefab aleatorio del array
        int prefabIndex = Random.Range(0, prefab.Length);

        // Calcula una distancia aleatoria entre el rango mínimo y el máximo
        float distancia = Random.Range(rangoMinimo, rangoMaximo);

        // Calcula un ángulo aleatorio en radianes
        float angulo = Random.Range(0f, Mathf.PI * 2);

        // Calcula la posición a partir de la distancia y el ángulo, alrededor del jugador (solo en X e Y)
        float x = Mathf.Cos(angulo) * distancia;
        float y = Mathf.Sin(angulo) * distancia; // Cambiado a 'y' para 2D

        // La posición final alrededor del jugador (solo en X e Y)
        Vector3 posicionAleatoria = player.position + new Vector3(x, y, 0.0f); // Z es 0 para 2D

        // Instancia el prefab aleatorio en la posición calculada
        Instantiate(prefab[prefabIndex], posicionAleatoria, Quaternion.identity);
    }

    // Si deseas probarlo desde el Inspector (opcional)
    private void OnDrawGizmosSelected()
    {
        if (player == null) return;

        // Dibuja el área de rango mínimo y máximo alrededor del jugador
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(player.position, rangoMinimo);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.position, rangoMaximo);
    }
}

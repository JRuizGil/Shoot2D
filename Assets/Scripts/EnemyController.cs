using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Variables expuestas en el Inspector
    public GameObject[] prefab; // Array de prefabs que se van a instanciar
    public float rangoMinimo = 5f; // Distancia m�nima desde el jugador
    public float rangoMaximo = 10f; // Distancia m�xima desde el jugador
    public float spawnInterval = 5f; // Intervalo de tiempo entre spawns en segundos
    public Transform player; // Referencia al jugador para instanciar alrededor de �l

    private void Start()
    {
        // Inicia la corrutina que spawnea enemigos cada 'spawnInterval' segundos
        StartCoroutine(SpawnEnemies());
    }

    // Corrutina para spawnear enemigos de forma peri�dica
    IEnumerator SpawnEnemies()
    {
        while (true) // Bucle infinito para spawnear indefinidamente
        {
            Instanciar(); // Instancia el prefab
            yield return new WaitForSeconds(spawnInterval); // Espera el intervalo antes de spawnear otro
        }
    }

    // M�todo para instanciar un prefab aleatorio alrededor del jugador
    public void Instanciar()
    {
        if (player == null)
        {
            Debug.LogWarning("No se ha asignado un jugador en el campo 'player'.");
            return;
        }

        // Selecciona un prefab aleatorio del array
        int prefabIndex = Random.Range(0, prefab.Length);

        // Calcula una distancia aleatoria entre el rango m�nimo y el m�ximo
        float distancia = Random.Range(rangoMinimo, rangoMaximo);

        // Calcula un �ngulo aleatorio en radianes
        float angulo = Random.Range(0f, Mathf.PI * 2);

        // Calcula la posici�n a partir de la distancia y el �ngulo, alrededor del jugador (solo en X e Y)
        float x = Mathf.Cos(angulo) * distancia;
        float y = Mathf.Sin(angulo) * distancia; // Cambiado a 'y' para 2D

        // La posici�n final alrededor del jugador (solo en X e Y)
        Vector3 posicionAleatoria = player.position + new Vector3(x, y, 0.0f); // Z es 0 para 2D

        // Instancia el prefab aleatorio en la posici�n calculada
        Instantiate(prefab[prefabIndex], posicionAleatoria, Quaternion.identity);
    }

    // Si deseas probarlo desde el Inspector (opcional)
    private void OnDrawGizmosSelected()
    {
        if (player == null) return;

        // Dibuja el �rea de rango m�nimo y m�ximo alrededor del jugador
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(player.position, rangoMinimo);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.position, rangoMaximo);
    }
}

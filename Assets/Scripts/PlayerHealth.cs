using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public float maxHealth = 100f; // Vida máxima del jugador
    private float currentHealth; // Vida actual
    public Scrollbar healthScrollbar; // Referencia a la barra de salud
    public GameObject objectToDeactivate; // GameObject que se desactivará al llegar a 0 de salud
    public GameObject objectToActivate; // GameObject que se activará al llegar a 0 de salud

    void Start()
    {
        currentHealth = maxHealth; // Inicializa la salud actual
        UpdateHealthUI(); // Actualiza la UI al inicio
    }

    void UpdateHealthUI()
    {
        healthScrollbar.size = currentHealth / maxHealth; // Actualiza el tamaño de la barra de salud
    }

    public void TakeDamage()
    {
        // Reduce la vida en un 25%
        currentHealth -= maxHealth * 0.25f;
        if (currentHealth < 0)
        {
            currentHealth = 0; // Asegúrate de que no baje de cero
            HandleDeath(); // Maneja la muerte del jugador
        }

        UpdateHealthUI(); // Actualiza la UI
    }

    void HandleDeath()
    {
        if (objectToDeactivate != null)
        {
            objectToDeactivate.SetActive(false); // Desactiva el GameObject asignado
        }

        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true); // Activa el GameObject asignado
        }
    }

    // Método para detectar colisiones
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Comprueba si el objeto con el que colisionamos tiene la etiqueta "EnemyBullet"
        if (other.CompareTag("EnemyBullet"))
        {
            TakeDamage(); // Reduce la vida del jugador
            Destroy(other.gameObject); // Destruye la bala enemiga después de la colisión
        }
    }
}

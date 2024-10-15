using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public float maxHealth = 100f; // Vida m�xima del jugador
    private float currentHealth; // Vida actual
    public Scrollbar healthScrollbar; // Referencia a la barra de salud
    public GameObject objectToDeactivate; // GameObject que se desactivar� al llegar a 0 de salud
    public GameObject objectToActivate; // GameObject que se activar� al llegar a 0 de salud

    void Start()
    {
        currentHealth = maxHealth; // Inicializa la salud actual
        UpdateHealthUI(); // Actualiza la UI al inicio
    }

    void UpdateHealthUI()
    {
        healthScrollbar.size = currentHealth / maxHealth; // Actualiza el tama�o de la barra de salud
    }

    public void TakeDamage()
    {
        // Reduce la vida en un 25%
        currentHealth -= maxHealth * 0.25f;
        if (currentHealth < 0)
        {
            currentHealth = 0; // Aseg�rate de que no baje de cero
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

    // M�todo para detectar colisiones
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Comprueba si el objeto con el que colisionamos tiene la etiqueta "EnemyBullet"
        if (other.CompareTag("EnemyBullet"))
        {
            TakeDamage(); // Reduce la vida del jugador
            Destroy(other.gameObject); // Destruye la bala enemiga despu�s de la colisi�n
        }
    }
}

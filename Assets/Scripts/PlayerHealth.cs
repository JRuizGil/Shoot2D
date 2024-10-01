using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Vida m�xima
    private float currentHealth; // Vida actual
    public Scrollbar healthScrollbar; // Referencia al scrollbar

    void Start()
    {
        currentHealth = maxHealth; // Inicializa la salud actual
        UpdateHealthUI(); // Actualiza la UI al inicio
    }

    void UpdateHealthUI()
    {
        healthScrollbar.size = currentHealth / maxHealth; // Actualiza el tama�o del scrollbar
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount; // Reduce la vida
        if (currentHealth < 0)
            currentHealth = 0; // Aseg�rate de que no baje de cero

        UpdateHealthUI(); // Actualiza la UI
    }

    public void Heal(float amount)
    {
        currentHealth += amount; // Aumenta la vida
        if (currentHealth > maxHealth)
            currentHealth = maxHealth; // Aseg�rate de que no sobrepase la m�xima

        UpdateHealthUI(); // Actualiza la UI
    }
}

public class TestDamage : MonoBehaviour
{
    public PlayerHealth playerHealth;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Presiona espacio para recibir da�o
        {
            playerHealth.TakeDamage(10f);
        }

        if (Input.GetKeyDown(KeyCode.H)) // Presiona 'H' para curarse
        {
            playerHealth.Heal(10f);
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab de la bala que se va a disparar
    public float shootInterval = 2f; // Intervalo de disparo (cada cuantos segundos dispara)
    public float bulletSpeed = 10f; // Velocidad a la que la bala se desplaza
    private GameObject targetPlayer; // Referencia al jugador m�s cercano

    void Start()
    {
        // Iniciar la corrutina para disparar balas continuamente
        StartCoroutine(ShootBullets());
    }

    // Corrutina que dispara balas cada 'shootInterval' segundos
    IEnumerator ShootBullets()
    {
        while (true)
        {
            // Buscar el jugador m�s cercano con el tag "Player"
            targetPlayer = GameObject.FindGameObjectWithTag("Player");

            if (targetPlayer != null)
            {
                // Dispara la bala hacia el jugador
                ShootAtPlayer(targetPlayer.transform);
            }

            // Esperar el intervalo antes de disparar otra vez
            yield return new WaitForSeconds(shootInterval);
        }
    }

    // M�todo para disparar una bala hacia la posici�n del jugador
    void ShootAtPlayer(Transform player)
    {
        // Instanciar la bala en la posici�n del enemigo
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // Calcular la direcci�n hacia el jugador
        Vector3 direction = (player.position - transform.position).normalized;

        // Asignar velocidad a la bala en direcci�n al jugador
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        if (bulletRb != null)
        {
            bulletRb.velocity = direction * bulletSpeed;
        }
    }
}

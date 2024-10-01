using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;    // Prefab del proyectil
    public Transform firePoint;        // Punto de salida del proyectil
    public float bulletSpeed = 10f;    // Velocidad del proyectil

    void Update()
    {
        // Detectar clic izquierdo del ratón
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Obtener la posición del clic en el mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Asegurarse de que esté en 2D

        // Calcular la dirección del disparo
        Vector3 shootDirection = (mousePosition - firePoint.position).normalized;

        // Instanciar el proyectil
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Obtener el Rigidbody2D del proyectil y aplicar velocidad en la dirección calculada
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = shootDirection * bulletSpeed;
    }
}

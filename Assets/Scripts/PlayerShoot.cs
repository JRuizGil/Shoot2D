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
        // Detectar clic izquierdo del rat�n
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Obtener la posici�n del clic en el mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Asegurarse de que est� en 2D

        // Calcular la direcci�n del disparo
        Vector3 shootDirection = (mousePosition - firePoint.position).normalized;

        // Instanciar el proyectil
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Obtener el Rigidbody2D del proyectil y aplicar velocidad en la direcci�n calculada
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = shootDirection * bulletSpeed;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float maxDistance = 20f;  // Distancia m�xima que puede recorrer el proyectil
    private Vector2 startPosition;   // Posici�n inicial del proyectil

    void Start()
    {
        // Guardar la posici�n inicial del proyectil
        startPosition = transform.position;
    }

    void Update()
    {
        // Verificar si el proyectil ha recorrido m�s que la distancia m�xima
        if (Vector2.Distance(startPosition, transform.position) >= maxDistance)
        {
            Destroy(gameObject);  // Destruir el proyectil si ha ido muy lejos
        }
    }    
}



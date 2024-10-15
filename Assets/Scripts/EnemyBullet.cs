using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float maxDistance = 20f;  // Distancia máxima que puede recorrer el proyectil
    private Vector2 startPosition;   // Posición inicial del proyectil

    void Start()
    {
        // Guardar la posición inicial del proyectil
        startPosition = transform.position;
    }

    void Update()
    {
        // Verificar si el proyectil ha recorrido más que la distancia máxima
        if (Vector2.Distance(startPosition, transform.position) >= maxDistance)
        {
            Destroy(gameObject);  // Destruir el proyectil si ha ido muy lejos
        }
    }    
}



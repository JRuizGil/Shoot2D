using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    // Referencia al objeto jugador
    public Transform player;

    // Distancia entre el jugador y el arma
    public float weaponDistance = 1.5f;

    // Update se llama una vez por frame
    void Update()
    {
        // Obtenemos la posici�n del mouse en la pantalla y la convertimos a coordenadas del mundo 2D
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calculamos la direcci�n hacia la que se apunta
        Vector2 direction = new Vector2(
            mousePosition.x - player.position.x,
            mousePosition.y - player.position.y
        );

        // Normalizamos la direcci�n (vector unitario)
        direction.Normalize();

        // Ajustamos la posici�n del arma fuera del jugador en la direcci�n hacia donde se apunta
        transform.position = player.position + new Vector3(direction.x, direction.y, 0) * weaponDistance;

        // Rotamos el arma para que apunte hacia la direcci�n del mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Si el jugador apunta hacia la izquierda (posici�n X negativa), invertimos el arma
        if (direction.x < 0)
        {
            // Cambiamos la escala del arma para "invertirla"
            transform.localScale = new Vector3(1, -1, 1); // Invertimos en el eje Y para reflejarla
        }
        else
        {
            // Restauramos la escala normal cuando apunta hacia la derecha
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}




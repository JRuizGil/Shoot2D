using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El personaje a seguir
    public Vector3 offset; // Offset para la posici�n de la c�mara
    public float followSpeed = 10f; // Velocidad de seguimiento

    void Start()
    {
        // Aseg�rate de que el offset est� bien configurado
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // Calcula la nueva posici�n de la c�mara
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}


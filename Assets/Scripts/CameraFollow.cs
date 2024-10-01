using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El personaje a seguir
    public Vector3 offset; // Offset para la posición de la cámara
    public float followSpeed = 10f; // Velocidad de seguimiento

    void Start()
    {
        // Asegúrate de que el offset esté bien configurado
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // Calcula la nueva posición de la cámara
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoGiratorio : MonoBehaviour
{
    public float velocidadRotacion = 50f; // Velocidad de rotación en grados por segundo
    public bool girarEnSentidoHorario = true; // Controla la dirección de la rotación

    void Update()
    {
        // Determina la dirección de rotación
        float direccion = (girarEnSentidoHorario) ? 1f : -1f;

        // Rotar el obstáculo alrededor del eje Y
        transform.Rotate(Vector3.up * direccion * velocidadRotacion * Time.deltaTime);
    }

}

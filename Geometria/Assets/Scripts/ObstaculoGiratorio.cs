using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoGiratorio : MonoBehaviour
{
    public float velocidadRotacion = 50f; // Velocidad de rotaci�n en grados por segundo
    public bool girarEnSentidoHorario = true; // Controla la direcci�n de la rotaci�n

    void Update()
    {
        // Determina la direcci�n de rotaci�n
        float direccion = (girarEnSentidoHorario) ? 1f : -1f;

        // Rotar el obst�culo alrededor del eje Y
        transform.Rotate(Vector3.up * direccion * velocidadRotacion * Time.deltaTime);
    }

}

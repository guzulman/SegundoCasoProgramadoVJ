using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenduloMovimiento : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    float amplitud = 45f; // Amplitud del movimiento (en grados)

    [SerializeField]
    float velocidad = 1f; // Velocidad de oscilaci�n (en grados por segundo)

    private Vector3 rotacionInicial;

    void Start()
    {
        rotacionInicial = transform.rotation.eulerAngles;
    }

    void Update()
    {
        // Calcula el �ngulo de oscilaci�n usando la funci�n seno
        float angulo = rotacionInicial.y + amplitud * Mathf.Sin(velocidad * Time.time);

        // Aplica la rotaci�n al p�ndulo
        transform.rotation = Quaternion.Euler(rotacionInicial.x, angulo, rotacionInicial.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenduloMovimiento : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    float amplitud = 45f; // Amplitud del movimiento (en grados)

    [SerializeField]
    float velocidad = 1f; // Velocidad de oscilación (en grados por segundo)

    private Vector3 rotacionInicial;

    void Start()
    {
        rotacionInicial = transform.rotation.eulerAngles;
    }

    void Update()
    {
        // Calcula el ángulo de oscilación usando la función seno
        float angulo = rotacionInicial.y + amplitud * Mathf.Sin(velocidad * Time.time);

        // Aplica la rotación al péndulo
        transform.rotation = Quaternion.Euler(rotacionInicial.x, angulo, rotacionInicial.z);
    }
}

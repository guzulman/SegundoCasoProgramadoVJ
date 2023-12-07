using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLimites : MonoBehaviour
{
    [SerializeField]
    float velocidadMovimiento = 5f; // Velocidad de movimiento

    [SerializeField]    
    float tiempoDeEspera = 2f; // Tiempo de espera antes de invertir la dirección

    [SerializeField]
    Vector3 posicionOriginal;

    [SerializeField]
    bool enMovimiento = true;

    void Start()
    {
        posicionOriginal = transform.position;
        StartCoroutine(MoverObstaculo());
    }

    IEnumerator MoverObstaculo()
    {
        while (true)
        {
            while (enMovimiento)
            {
                // Mover hacia adelante
                transform.Translate(Vector3.right * velocidadMovimiento * Time.deltaTime);
                yield return null;
            }

            // Esperar un tiempo
            yield return new WaitForSeconds(tiempoDeEspera);

            // Volver a la posición original
            transform.position = posicionOriginal;

            
        }
    }
}

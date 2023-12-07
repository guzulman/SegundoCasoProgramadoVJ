using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    [SerializeField]
    float tiempoLimite = 300f; // Tiempo límite en segundos

    [SerializeField]
    float tiempoRestante;

    public Text textoTiempo; // Asigna un objeto de texto desde el Inspector

    void Start()
    {
        tiempoRestante = tiempoLimite;
    }

    void Update()
    {
        tiempoRestante -= Time.deltaTime;
        ActualizarTextoTiempo();

        if (tiempoRestante <= 0f)
        {
            // Lógica para indicar que el tiempo ha terminado y el jugador ha perdido
            Debug.Log("¡Tiempo agotado! Perdiste.");

            // Puedes reiniciar el nivel o realizar otras acciones aquí
        }
    }

    void ActualizarTextoTiempo()
    {
        // Actualizar el texto del temporizador (puedes personalizar el formato)
        int minutos = Mathf.FloorToInt(tiempoRestante / 60f);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60f);
        textoTiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}

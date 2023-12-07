using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoEsferico : MonoBehaviour
{
    public float fuerzaRebote = 10f; // Fuerza de rebote al tocar el obstáculo

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Calcula la dirección del rebote
            Vector3 direccionRebote = (transform.position - collision.transform.position).normalized;

            // Aplica fuerza al jugador para que rebote
            GetComponent<Rigidbody>().AddForce(direccionRebote * fuerzaRebote, ForceMode.Impulse);
        }
    }
}

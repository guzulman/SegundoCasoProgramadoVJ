using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballController : MonoBehaviour
{
    [SerializeField]
    float force;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * force;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }   
}

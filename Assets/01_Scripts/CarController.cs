using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10f;  // Velocidad del veh�culo hacia adelante.

    private void Start()
    {
        // Aplica una fuerza hacia adelante al RigidBody del veh�culo para hacerlo moverse.
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el veh�culo colisiona con un objeto que no sea la calle.
        if (!collision.gameObject.CompareTag("Street"))
        {
            // Destruye el veh�culo cuando deja de colisionar con la calle.
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}

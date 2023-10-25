using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Trampolin : Distract
{
    public float jumpForce = 5.0f; // Fuerza de salto que se aplicar� al objeto Kid
    private Kid kid; // Referencia al objeto Kid con el que colisionamos

    // Este m�todo se ejecuta cuando el objeto con este script colisiona con otro objeto que tiene un Collider.
    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto con el que colisionamos tiene la etiqueta "Kid".
        if (other.gameObject.CompareTag("Kid"))
        {
            // Obtenemos una referencia al componente Kid adjunto al objeto colisionado.
            kid = other.gameObject.GetComponent<Kid>();
        }
    }

    // Este m�todo se ejecuta en cada actualizaci�n del juego.
    private void Update()
    {
        // Verificamos si tenemos una referencia v�lida al objeto Kid.
        if (kid != null)
        {
            // Aplicamos una fuerza hacia arriba constante al objeto Kid para hacerlo saltar continuamente.
            kid.rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Este m�todo se ejecuta cuando el objeto con este script sale de la colisi�n con otro objeto.
    private void OnTriggerExit(Collider other)
    {
        // Verificamos si el objeto con el que est�bamos colisionando es el objeto Kid.
        if (other.gameObject.CompareTag("Kid"))
        {
            // Establecemos la referencia a Kid como nula, lo que detendr� el salto.
            kid = null;
        }
    }
}
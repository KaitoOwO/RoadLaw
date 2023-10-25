using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    public float minJumpForce = 5.0f; // Fuerza de salto m�nima
    public float maxJumpForce = 10.0f; // Fuerza de salto m�xima
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
            // Generamos una fuerza aleatoria en una direcci�n aleatoria.
            Vector3 randomJumpForce = new Vector3(
                Random.Range(-1f, 1f), // Componente X (direcci�n horizontal)
                Random.Range(0.5f, 1f), // Componente Y (direcci�n vertical)
                Random.Range(-1f, 1f)  // Componente Z (direcci�n lateral)
            );

            // Normalizamos el vector y luego aplicamos una fuerza dentro del rango especificado.
            randomJumpForce.Normalize();
            float forceMagnitude = Random.Range(minJumpForce, maxJumpForce);
            randomJumpForce *= forceMagnitude;

            // Aplicamos la fuerza al objeto Kid.
            kid.rb.AddForce(randomJumpForce, ForceMode.Impulse);
            KidDead();
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

    IEnumerator KidDead()
    {
        GameManager.instance.vidas--;
        Destroy(kid);
        yield return new WaitForSeconds(4f);
    }
}


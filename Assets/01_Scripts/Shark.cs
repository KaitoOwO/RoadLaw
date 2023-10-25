using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Kid"))
        {
            GameManager.instance.vidas--;
            Destroy(collision.gameObject);
        }
    }
}

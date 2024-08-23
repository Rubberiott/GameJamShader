using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderOxygen : MonoBehaviour
{
    public bool colision = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cabeza"))
        {
            colision = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cabeza"))
        {
            colision = false;
        }
    }
}

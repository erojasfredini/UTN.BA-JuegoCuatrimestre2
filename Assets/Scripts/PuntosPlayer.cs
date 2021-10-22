using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntosPlayer : MonoBehaviour
{
    public int puntos = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            ++puntos;
        }
    }
}

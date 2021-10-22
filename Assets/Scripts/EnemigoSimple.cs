using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoSimple : MonoBehaviour
{
    public float velocidad = 1.0f;
    public float epsilonDistancia = 0.1f;
    public Transform puntoA;
    public Transform puntoB;
    private enum Objetivo { PuntoA, PuntoB };
    private Objetivo actual;

    private Transform objetivoActual;
    private Rigidbody rb;

    void Start()
    {
        puntoA.position = new Vector3(puntoA.position.x, transform.position.y, puntoA.position.z);
        puntoB.position = new Vector3(puntoB.position.x, transform.position.y, puntoB.position.z);
        objetivoActual = puntoA;
        actual = Objetivo.PuntoA;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 dir = objetivoActual.position - transform.position;
        float distancia = dir.magnitude;
        dir.Normalize();

        rb.velocity = dir * velocidad;

        // Mirar a donde nos estamos moviendo
        var vel = rb.velocity;
        vel.y = 0.0f;
        if (vel.magnitude > 0.1f)
        {
            var dirMov = rb.velocity.normalized;
            rb.rotation = Quaternion.LookRotation(dirMov, Vector3.up);
        }

        //Debug.Log($"La distancia es {distancia}");
        if (distancia < epsilonDistancia)
        {
            if (actual == Objetivo.PuntoA)
            {
                objetivoActual = puntoB;
                actual = Objetivo.PuntoB;
            }else
            {
                objetivoActual = puntoA;
                actual = Objetivo.PuntoA;
            }
        }
    }
}

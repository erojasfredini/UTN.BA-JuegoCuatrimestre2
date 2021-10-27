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

        // Aumenta la velocidad cuando ve al player
        float velocidadActual = velocidad;
        Ray rayo = new Ray(transform.position, dir);
        int layerPlayers = 1 << LayerMask.NameToLayer("Players");
        int mascara = layerPlayers;
        if (Physics.Raycast(rayo, mascara))
        {
            velocidadActual *= 2.0f;
        }

        rb.velocity = dir * velocidadActual;

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

        //int layerPlayer = 1 << LayerMask.NameToLayer("Players");
        ////int layerItems = 1 << LayerMask.NameToLayer("Items");
        ////int mascara = layerPlayer | layerItems;
        //int mascara = layerPlayer;
        //float radio = 1.0f;
        //if (Physics.CheckSphere(transform.position, radio, mascara))
        //{
        //    GameObject.Destroy(gameObject);
        //}
    }

    //private void OnDrawGizmosSelected()
    //{
    //    float radio = 1.0f;
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawSphere(transform.position, radio);
    //}
}

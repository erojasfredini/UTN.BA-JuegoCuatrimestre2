using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    public float velocidad = 1.0f;
    private Rigidbody rb;

    void Start()
    {
         rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rb.velocity = (h * Vector3.right + v * Vector3.forward) * velocidad;
    }
}

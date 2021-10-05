using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    public float velocidad = 10.0f;
    private Rigidbody rb;

    void Start()
    {
         rb = GetComponent<Rigidbody>();
    }
    private float h;
    private float v;
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        rb.velocity = (h * Vector3.right + v * Vector3.forward) * velocidad;
    }
}

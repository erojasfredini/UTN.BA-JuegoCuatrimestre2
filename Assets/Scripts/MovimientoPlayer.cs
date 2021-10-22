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
        // Movimiento
        if (Mathf.Abs(h) > 0.1f)
            rb.velocity = h * Vector3.right * velocidad;
        else if (Mathf.Abs(v) > 0.1f)
            rb.velocity = v * Vector3.forward * velocidad;

        // Mirar a donde nos estamos moviendo
        var vel = rb.velocity;
        vel.y = 0.0f;
        if (vel.magnitude > 0.1f)
        {
            var dirMov = rb.velocity.normalized;
            rb.rotation = Quaternion.LookRotation(dirMov, Vector3.up);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlatformer : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    public float vel = 1.0f;
    public bool useRootMotion = true;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Solo prueba
        if (anim.applyRootMotion != useRootMotion)
        {
            anim.applyRootMotion = useRootMotion;
            if (!anim.applyRootMotion)
            {
                if (GetComponent<Rigidbody>() == null)
                {
                    rb = gameObject.AddComponent<Rigidbody>();
                    rb.freezeRotation = true;
                }
            }
            else
            {
                if (GetComponent<Rigidbody>() != null)
                    GameObject.Destroy(GetComponent<Rigidbody>());
            }
        }

        // Aca simulacion
        if (!useRootMotion)
        {
            rb.velocity = vel * transform.forward * v + vel * transform.right * h;
        }

        anim.SetFloat("Horizontal", h);
        anim.SetFloat("Vertical", v);
    }
}

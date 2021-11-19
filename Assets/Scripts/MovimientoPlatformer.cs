using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlatformer : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    public float vel = 1.0f;
    public float velSalto = 5.0f;
    public bool useRootMotion = true;
    private AudioSource audio;
    public List<AudioClip> sonidosPisadasWalk;
    public List<AudioClip> sonidosPisadasRun;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        audio = GetComponent<AudioSource>();
    }

    public float velRotacion = 1.0f;
    public bool isPiso;
    private Vector3 prevMousePos = Vector3.zero;

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

        float m = Input.GetAxis("Mirar");
        Debug.Log($"Mirar {m}");
        //Debug.Log($"{m}");
        //Vector3 deltaMousePos = Input.mousePosition - prevMousePos;
        //transform.Rotate(Vector3.up, deltaMousePos.x * Time.deltaTime * velRotacion);
        transform.Rotate(Vector3.up, m * Time.deltaTime * velRotacion);
        prevMousePos = Input.mousePosition;

        int mascara = 1 << LayerMask.NameToLayer("Ground");
        isPiso = Physics.Raycast(transform.position + Vector3.up * deltaUpCheckPiso, Vector3.down, distPiso, mascara);
        anim.SetBool("IsPiso", isPiso);

        // Aca simulacion
        if (!useRootMotion)
        {
            rb.velocity = vel * transform.forward * v + vel * transform.right * h + rb.velocity.y * Vector3.up;
        }

        bool a = Input.GetButtonDown("Fire1");
        if (a)
            anim.SetTrigger("Attack");

        bool j = Input.GetButtonDown("Jump");
        bool estaSaltando = j && isPiso;
        //anim.SetBool("Salto", estaSaltando);
        if (estaSaltando)
            anim.SetTrigger("Salto");
        if (estaSaltando && (rb != null))
        {
            rb.velocity = rb.velocity + Vector3.up * velSalto;
        }

        //Debug.Log($"{rb.velocity}");

        anim.SetFloat("Horizontal", h);
        anim.SetFloat("Vertical", v);
    }

    public float distPiso = 0.44f;
    public float deltaUpCheckPiso = 0.4f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 origen = transform.position + Vector3.up * deltaUpCheckPiso;
        Gizmos.DrawLine(origen, origen + Vector3.down * distPiso);
    }

    public void OnAttack()
    {
        Debug.Log("Ataque");
    }

    public void OnPisada()
    {
        List<AudioClip> sonidos = null;
        if (rb.velocity.magnitude > (vel * 0.6f))
        {
            sonidos = sonidosPisadasRun;
        }
        else
        {
            sonidos = sonidosPisadasWalk;
        }

        if (audio != null && sonidos != null && sonidos.Count > 0)
        {
            int indice = UnityEngine.Random.Range(0, sonidos.Count - 1);
            audio.PlayOneShot(sonidos[indice]);
        }
    }
}

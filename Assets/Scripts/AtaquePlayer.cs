using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaquePlayer : MonoBehaviour
{
    public GameObject prefabBomba;
    public GameObject prefabBombaArrojadiza;
    public float potenciaDireccion = 2.0f;
    public float potenciaArriba = 3.0f;

    public float tiempoCoolDown = 1.0f;
    private float coolDown = 0.0f;

    void Update()
    {
        coolDown = Mathf.Clamp(coolDown - Time.deltaTime, 0.0f, tiempoCoolDown);
        bool dejoBomba = Input.GetButtonDown("Fire1");
        if (dejoBomba && (coolDown == 0.0f))
        {
            coolDown = tiempoCoolDown;
            GameObject.Instantiate(prefabBomba, transform.position, Quaternion.identity);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            var rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
            int layerPiso = 1 << LayerMask.NameToLayer("Ground");
            int mascara = layerPiso;
            RaycastHit hit;
            if (Physics.Raycast(rayo, out hit, layerPiso))
            {
                //Debug.Log($"Picking {hit.collider.name}");
                Vector3 posPlayer = transform.position;
                posPlayer.y = 0.0f;
                Vector3 posTarget = hit.point;
                posTarget.y = 0.0f;
                Vector3 direccion = (posTarget - posPlayer).normalized;
                var bomba = GameObject.Instantiate(prefabBombaArrojadiza, transform.position + Vector3.up * 1.0f, Quaternion.identity);
                var rb = bomba.GetComponent<Rigidbody>();
                rb.velocity = direccion * potenciaDireccion + Vector3.up * potenciaArriba;
            }
        }
    }

    private void OnDrawGizmos()
    {
        var rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        Gizmos.DrawLine(rayo.origin, rayo.direction * 100.0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    public float tiempoDetonacionMinimo = 5.0f;
    public float tiempoDetonacionMaximo = 10.0f;

    void Start()
    {
        float timepo = Random.Range(tiempoDetonacionMinimo, tiempoDetonacionMaximo);
        //Debug.Log($"Bomba revienta en {timepo}");
        Invoke("Reventar", timepo);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Se hace solido!");
            var col = GetComponent<SphereCollider>();
            col.isTrigger = false;
        }
    }

    private void Reventar()
    {
        // BOOM
        Debug.Log("BOOM!");
        GameObject.Destroy(gameObject);
    }

}

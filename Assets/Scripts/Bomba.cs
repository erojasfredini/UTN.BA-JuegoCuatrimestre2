using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    public float tiempoDetonacionMinimo = 5.0f;
    public float tiempoDetonacionMaximo = 10.0f;
    public GameObject prefabExplosion;

    public float desplazamientoGrilla = 1.0f;
    public int radioExplosion = 1;

    public float minPitch = 1.0f;
    public float maxPitch = 1.0f;
    public AudioClip sonidoExplosion;

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

        float pitch = UnityEngine.Random.Range(minPitch, maxPitch);
        // Alternativa singleton
        //var mgrAudio = MgrAudio.GetInstancia();
        //mgrAudio.ReproducirSoundFX(sonidoExplosion, transform.position, pitch);

        var mgr = GameObject.Find("ManagerAudio");
        var mgrAudio = mgr.GetComponent<ManagerAudio>();
        mgrAudio.ReproducirSoundFX(sonidoExplosion, transform.position, pitch);

        // Crear explosiones
        GameObject.Instantiate(prefabExplosion, transform.position, Quaternion.identity);
        // Vecino Norte
        for (int i=0; i < radioExplosion; ++i)
            GameObject.Instantiate(prefabExplosion, transform.position + Vector3.forward * desplazamientoGrilla * (i + 1), Quaternion.identity);
        // Vecino Sur
        for (int i = 0; i < radioExplosion; ++i)
            GameObject.Instantiate(prefabExplosion, transform.position - Vector3.forward * desplazamientoGrilla * (i + 1), Quaternion.identity);
        // Vecino Oeste
        for (int i = 0; i < radioExplosion; ++i)
            GameObject.Instantiate(prefabExplosion, transform.position - Vector3.right * desplazamientoGrilla * (i + 1), Quaternion.identity);
        // Vecino Este
        for (int i = 0; i < radioExplosion; ++i)
            GameObject.Instantiate(prefabExplosion, transform.position + Vector3.right * desplazamientoGrilla * (i + 1), Quaternion.identity);

        GameObject.Destroy(gameObject);
    }

}

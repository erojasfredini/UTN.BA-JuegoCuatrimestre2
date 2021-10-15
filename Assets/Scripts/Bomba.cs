using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    public float tiempoDetonacionMinimo = 5.0f;
    public float tiempoDetonacionMaximo = 10.0f;

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
        GameObject.Destroy(gameObject);
    }

}

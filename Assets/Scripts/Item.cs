using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public AudioClip sonido;
    public float minPitch = 1.0f;
    public float maxPitch = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var mgr = GameObject.Find("ManagerAudio");
            var mgrAudio = mgr.GetComponent<ManagerAudio>();
            float pitch = UnityEngine.Random.Range(minPitch, maxPitch);
            mgrAudio.ReproducirSoundFX(sonido, transform.position, pitch);
            GameObject.Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public AudioClip sonido;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var mgr = GameObject.Find("ManagerAudio");
            var mgrAudio = mgr.GetComponent<ManagerAudio>();
            mgrAudio.ReproducirSoundFX(sonido, transform.position);
            GameObject.Destroy(gameObject);
        }
    }
}

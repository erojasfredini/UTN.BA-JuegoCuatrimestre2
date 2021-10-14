using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAudio : MonoBehaviour
{
    public GameObject prefabSoundFX;
    public int cantidadPool;

    private AudioSource[] sources;
    private Transform[] sourceTrans;
    private int indiceSiguienteUso = 0;

    private void Start()
    {
        sources = new AudioSource[cantidadPool];
        sourceTrans = new Transform[cantidadPool];

        for (int i = 0; i < cantidadPool; ++i)
        {
            var g = GameObject.Instantiate(prefabSoundFX, transform);
            sources[i] = g.GetComponent<AudioSource>();
            sourceTrans[i] = g.transform;
        }
    }

    public void ReproducirSoundFX(AudioClip clip, Vector3 pos)
    {
        sourceTrans[indiceSiguienteUso].position = pos;
        sources[indiceSiguienteUso].PlayOneShot(clip);
        indiceSiguienteUso = (indiceSiguienteUso + 1) % sources.Length;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class MgrAudio
//{
//    private static MgrAudio instancia = null;

//    public AudioClip Musica;
//    private AudioSource sourceMusica;

//    public GameObject prefabSoundFX;
//    public int cantidadPool;

//    private MgrAudio()
//    {
//        //sourceMusica = GetComponent<AudioSource>();

//        sources = new AudioSource[cantidadPool];
//        sourceTrans = new Transform[cantidadPool];

//        for (int i = 0; i < cantidadPool; ++i)
//        {
//            var g = GameObject.Instantiate(prefabSoundFX);
//            sources[i] = g.GetComponent<AudioSource>();
//            sourceTrans[i] = g.transform;
//        }

//        sourceMusica.clip = Musica;
//        sourceMusica.Play();
//    }

//    public static MgrAudio GetInstancia()
//    {
//        if (instancia == null)
//            instancia = new MgrAudio();
//        return instancia;
//    }

//    private AudioSource[] sources;
//    private Transform[] sourceTrans;
//    private int indiceSiguienteUso = 0;

//    public void ReproducirSoundFX(AudioClip clip, Vector3 pos, float pitch)
//    {
//        Debug.Log($"Reproduciendo {clip.name} | Position {pos} | Pitch {pitch}");
//        sourceTrans[indiceSiguienteUso].position = pos;
//        sources[indiceSiguienteUso].pitch = pitch;
//        sources[indiceSiguienteUso].PlayOneShot(clip);
//        indiceSiguienteUso = (indiceSiguienteUso + 1) % sources.Length;
//    }
//}

public class ManagerAudio : MonoBehaviour
{
    public AudioClip Musica;
    private AudioSource sourceMusica;

    public GameObject prefabSoundFX;
    public int cantidadPool;

    private AudioSource[] sources;
    private Transform[] sourceTrans;
    private int indiceSiguienteUso = 0;

    private void Start()
    {
        sourceMusica = GetComponent<AudioSource>();

        sources = new AudioSource[cantidadPool];
        sourceTrans = new Transform[cantidadPool];

        for (int i = 0; i < cantidadPool; ++i)
        {
            var g = GameObject.Instantiate(prefabSoundFX, transform);
            sources[i] = g.GetComponent<AudioSource>();
            sourceTrans[i] = g.transform;
        }

        sourceMusica.clip = Musica;
        sourceMusica.Play();
    }

    public void ReproducirSoundFX(AudioClip clip, Vector3 pos, float pitch)
    {
        Debug.Log($"Reproduciendo {clip.name} | Position {pos} | Pitch {pitch}");
        sourceTrans[indiceSiguienteUso].position = pos;
        sources[indiceSiguienteUso].pitch = pitch;
        sources[indiceSiguienteUso].PlayOneShot(clip);
        indiceSiguienteUso = (indiceSiguienteUso + 1) % sources.Length;
    }
}

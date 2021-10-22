using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque : MonoBehaviour
{
    public enum TipoBloque { Destruible, Indestructible };
    public TipoBloque tipoBloque = TipoBloque.Destruible;

    public List<GameObject> prefabBloques;
    public GameObject gizmoBloque;

    private void Start()
    {
        var bloqueModelo = GameObject.Instantiate(prefabBloques[Random.Range(0, prefabBloques.Count - 1)], transform);
        bloqueModelo.transform.localPosition = gizmoBloque.transform.localPosition;
        bloqueModelo.transform.localRotation = gizmoBloque.transform.localRotation;
        GameObject.Destroy(gizmoBloque);
    }
}

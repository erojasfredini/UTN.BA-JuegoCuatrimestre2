using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasBloque : MonoBehaviour
{
    private Bloque bloque;

    private void Start()
    {
        bloque = GetComponent<Bloque>();
    }

    public void Dano()
    {
        if (bloque.tipoBloque == Bloque.TipoBloque.Destruible)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
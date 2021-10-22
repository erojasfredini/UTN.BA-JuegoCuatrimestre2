using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpciones : MonoBehaviour
{
    public GameObject menuJugar;
    public GameObject menuOpciones;
    public void OnDificultad()
    {
        Debug.Log("Click en dificultad");
        // TODO
    }

    public void OnGraficos()
    {
        Debug.Log("Click en graficos");
        // TODO
    }

    public void OnAtras()
    {
        Debug.Log("Click en atras");
        menuJugar.SetActive(true);
        menuOpciones.SetActive(false);
    }
}

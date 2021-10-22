using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuJugar : MonoBehaviour
{
    public GameObject menuOpciones;
    public GameObject menuJugar;
    public void OnJugar()
    {
        Debug.Log("Click en jugar");
        SceneManager.LoadScene("Juego");
    }

    public void OnOpciones()
    {
        Debug.Log("Click en opciones");
        menuOpciones.SetActive(true);
        menuJugar.SetActive(false);
    }

    public void OnSalir()
    {
        Debug.Log("Click en salir");
        Application.Quit(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public PuntosPlayer puntosPlayer;
    public Text textoPuntos;

    private void Update()
    {
        textoPuntos.text = puntosPlayer.puntos.ToString();
    }
}

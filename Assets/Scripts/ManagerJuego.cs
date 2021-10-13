using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerJuego : MonoBehaviour
{
    public float tiempoGameOver = 3.0f;

    public void GameOver()
    {
        Debug.Log("Game Over!");
        Invoke("Reiniciar", tiempoGameOver);
    }

    private void Reiniciar()
    {
        SceneManager.LoadScene("Juego");
    }
}

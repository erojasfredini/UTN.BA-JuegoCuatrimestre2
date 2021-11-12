using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerJuego : MonoBehaviour
{
    public float tiempoGameOver = 3.0f;
    public int cantVidas = 3;
    public GameObject prefabPlayer;
    private Transform playerSpawn;

    private void Start()
    {
        playerSpawn = GameObject.Find("PlayerSpawn").transform;
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        Invoke("Reiniciar", tiempoGameOver);
    }

    private void Reiniciar()
    {
        --cantVidas;
        if (cantVidas == 0)
            SceneManager.LoadScene("Menu");
        {
            //SceneManager.LoadScene("Juego");
            GameObject.Instantiate(prefabPlayer, playerSpawn.position, playerSpawn.rotation);
        }
    }
}

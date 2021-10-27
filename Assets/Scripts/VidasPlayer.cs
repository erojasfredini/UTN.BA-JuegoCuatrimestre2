using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasPlayer : MonoBehaviour
{
    public GameObject prefabEfectoMuerte;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Morir();
        }
    }

    public void Morir()
    {
        GameObject.Destroy(gameObject);
        Debug.Log("Moriste");
        GameObject mgr = GameObject.Find("ManagerJuego");
        var mgrJuego = mgr.GetComponent<ManagerJuego>();

        GameObject.Instantiate(prefabEfectoMuerte, transform.position, transform.rotation);

        mgrJuego.GameOver();
    }
}

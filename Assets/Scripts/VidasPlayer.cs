using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasPlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            GameObject.Destroy(gameObject);
            Debug.Log("Moriste");
            var mgr = GameObject.Find("ManagerJuego");
            var mgrJuego = mgr.GetComponent<ManagerJuego>();
            mgrJuego.GameOver();
        }
    }
}

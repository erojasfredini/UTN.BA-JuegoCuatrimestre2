using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaquePlayer : MonoBehaviour
{
    public GameObject prefabBomba;

    public float tiempoCoolDown = 1.0f;
    private float coolDown = 0.0f;

    void Update()
    {
        coolDown = Mathf.Clamp(coolDown - Time.deltaTime, 0.0f, tiempoCoolDown);
        bool dejoBomba = Input.GetButtonDown("Fire1");
        if (dejoBomba && (coolDown == 0.0f))
        {
            coolDown = tiempoCoolDown;
            GameObject.Instantiate(prefabBomba, transform.position, Quaternion.identity);
        }
    }
}

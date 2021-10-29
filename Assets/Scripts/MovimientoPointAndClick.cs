using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoPointAndClick : MonoBehaviour
{
    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int layerPiso = 1 << LayerMask.NameToLayer("Ground");
        int mascara = layerPiso;
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hit, mascara))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}

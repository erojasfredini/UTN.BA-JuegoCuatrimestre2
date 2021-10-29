using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoRastreador : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        var p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
            player = p.transform;
    }

    void Update()
    {
        agent.SetDestination(player.position);
    }
}

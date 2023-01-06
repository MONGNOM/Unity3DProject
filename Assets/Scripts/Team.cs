using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class Team : MonoBehaviour
{
    [SerializeField]
    private MyTower Tower;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        agent.destination = Tower.transform.position;

    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}

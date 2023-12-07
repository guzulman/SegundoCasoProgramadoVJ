using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgentController : MonoBehaviour
{
    [SerializeField]
    Transform target;

    NavMeshAgent _navAgent;

    private void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _navAgent.SetDestination(target.position);
    }
}

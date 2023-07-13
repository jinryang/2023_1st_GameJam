using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAgentScript : MonoBehaviour
{
    [SerializeField] Transform target;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = GetComponent<PlayerInfo>().stat.moveSpeed;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    public void Setspeed(float value)
    {
        agent.speed = value;
    }

    void Update()
    {
        if (target.position.x < transform.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else if (target.position.x > transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        agent.SetDestination(target.position);
    }
}

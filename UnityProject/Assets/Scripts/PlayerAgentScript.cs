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
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        else if (target.position.x > transform.position.x)
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        agent.SetDestination(target.position);
    }
}

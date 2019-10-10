using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class Move : MonoBehaviour
{
    public GameObject[] destinations;

    private NavMeshAgent agent;
    private int index;

    
    // Start is called before the first frame update
    void Start()
    {
        agent=GetComponent<NavMeshAgent>();
        index = 0;
        agent.SetDestination(destinations[index].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        DestinationChoose();
    }
    private bool atDestination()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            return true;
        }
        return false;
    }
    private void DestinationChoose()
    {
        if (atDestination())
        {
            if(index < destinations.Length - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
            agent.SetDestination(destinations[index].transform.position);
        }
    }
}

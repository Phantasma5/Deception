using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public Transform[] points;
    public Transform target;
    Vector3 moveTo;
    NavMeshAgent npcAgent;
    int destinationPoint;

    // Start is called before the first frame update
    void Start()
    {
        npcAgent = GetComponent<NavMeshAgent>();
        npcAgent.autoBraking = false;
        NextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if(!npcAgent.pathPending && npcAgent.remainingDistance < 5.0f)
        {
            NextPoint();
        }
    }

    void NextPoint()
    {
        if(points.Length == 0)
        {
            return;
        }
        npcAgent.destination = points[destinationPoint].position;
        destinationPoint = (destinationPoint + 1) % points.Length;
    }
}

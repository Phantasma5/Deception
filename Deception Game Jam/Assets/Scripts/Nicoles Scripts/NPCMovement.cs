using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    NavMeshAgent npcAgent;
    public Transform target;
    Vector3 moveTo;

    // Start is called before the first frame update
    void Start()
    {
        npcAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        moveTo = target.position;
        npcAgent.destination = moveTo;
    }
}

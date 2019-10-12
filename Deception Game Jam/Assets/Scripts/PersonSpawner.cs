using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PersonSpawner : MonoBehaviour
{
    [SerializeField] private GameObject PersonPrefab;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float spawnTimer;
    private Rigidbody myRigidbody;
    private GameManager instance;
    private float spawnCD = 0;
    private bool moving = true;
    public Transform[] points;
    private NavMeshAgent carAgent;
    private int destinationPoint;
    private float carSpeed;

    private void Start()
    {
        instance = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        myRigidbody = GetComponent<Rigidbody>();
        carAgent = GetComponent<NavMeshAgent>();
        carAgent.autoBraking = false;
        carSpeed = carAgent.speed;
    }
    private void Update()
    {
        spawnCD += Time.deltaTime;
        if(spawnCD > spawnTimer && !instance.transformed)
        {
            spawnCD -= spawnTimer;
            StartCoroutine(SpawnPerson());
        }
        /*if(moving)
        {
            myRigidbody.velocity = transform.forward * movementSpeed;
        } */
        if(!carAgent.pathPending && carAgent.remainingDistance < 5f)
        {
            NextPoint();
        }
    }
    IEnumerator SpawnPerson()
    {
        //moving = false;
        carAgent.speed = 0;
        yield return new WaitForSeconds(2);
        GameObject temp = Instantiate(PersonPrefab, transform.position + new Vector3(3,0,0), Quaternion.identity);
        instance.myPersons.Add(temp);
        yield return new WaitForSeconds(1);
        //moving = true;
        carAgent.speed = carSpeed;
    }

    void NextPoint()
    {
        if(points.Length == 0)
        {
            return;
        }
        carAgent.destination = points[destinationPoint].position;
        destinationPoint = (destinationPoint + 1) % points.Length;
    }
}

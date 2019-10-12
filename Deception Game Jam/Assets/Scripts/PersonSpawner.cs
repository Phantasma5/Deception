using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSpawner : MonoBehaviour
{
    [SerializeField] private GameObject PersonPrefab;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float spawnTimer;
    private Rigidbody myRigidbody;
    private GameManager instance;
    private float spawnCD = 0;
    private bool moving = true;
    private void Start()
    {
        instance = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        myRigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        spawnCD += Time.deltaTime;
        if(spawnCD > spawnTimer)
        {
            spawnCD -= spawnTimer;
            StartCoroutine(SpawnPerson());
        }
        if(moving)
        {
            myRigidbody.velocity = transform.forward * movementSpeed;
        }
    }
    IEnumerator SpawnPerson()
    {
        moving = false;
        yield return new WaitForSeconds(2);
        GameObject temp = Instantiate(PersonPrefab, transform.position + new Vector3(1,0,0), Quaternion.identity);
        instance.myPersons.Add(temp);
        yield return new WaitForSeconds(1);
        moving = true;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class NPCBehaviorScript : MonoBehaviour
{
    [SerializeField]
    private int startTalk;
    public string playerTalk;
    public Text textBox;
    public bool spokenTo;
    public ParticleSystem trail;
    public Transform[] points;
    NavMeshAgent npcAgent;
    int destinationPoint;
    float npcSpeed;
    float playerDistance;
    private GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        startTalk = Random.Range(0, 2); //randomly choose what they are going to say;
        if (startTalk == 0)
        {
            playerTalk = "Yeehaw! Howdy partner!";
        }
        else if (startTalk == 1)
        {
            playerTalk = "Hi, hows it going?";
        }
        else if (startTalk == 2)
        {
            playerTalk = "Henlo!";
        }
        spokenTo = false;
        npcAgent = GetComponent<NavMeshAgent>(); //Set movement
        npcAgent.autoBraking = false;
        NextPoint();
        npcSpeed = npcAgent.speed;
        trail.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector3.Distance(transform.position, instance.player.transform.position);
        if(instance.transformed == true && playerDistance < 10f)
        {
            Vector3 playerAway = transform.position + (transform.position - instance.player.transform.position);
            npcAgent.destination = playerAway;
        }
        else if (!npcAgent.pathPending && npcAgent.remainingDistance < 5.0f)
        {
            NextPoint();
        }
        if(instance.transformed == true && spokenTo == true)
        {
            trail.Play();
        }
    }

    public IEnumerator PlayerIsSpeaking()
    {
        npcAgent.speed = 0f;
        transform.LookAt(instance.player.gameObject.transform);
        textBox.text = playerTalk;
        Debug.Log(textBox.text);
        spokenTo = true;
        yield return new WaitForSeconds(3f);
        textBox.text = "";
        npcAgent.speed = npcSpeed;
    }

    void NextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }
        npcAgent.destination = points[destinationPoint].position;
        destinationPoint = (destinationPoint + 1) % points.Length;
    }
}

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
    public Transform playerTransform;
    public Transform[] points;
    NavMeshAgent npcAgent;
    int destinationPoint;
    float npcSpeed;

    // Start is called before the first frame update
    void Start()
    {
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

        npcAgent = GetComponent<NavMeshAgent>(); //Set movement
        npcAgent.autoBraking = false;
        NextPoint();
        npcSpeed = npcAgent.speed;
        StartCoroutine("PlayerIsSpeaking");
    }

    // Update is called once per frame
    void Update()
    {
        if (!npcAgent.pathPending && npcAgent.remainingDistance < 5.0f)
        {
            NextPoint();
        }
    }

    public IEnumerator PlayerIsSpeaking()
    {
        npcAgent.speed = 0f;
        transform.LookAt(playerTransform);
        textBox.text = playerTalk;
        Debug.Log(textBox.text);
        yield return new WaitForSeconds(5f);
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

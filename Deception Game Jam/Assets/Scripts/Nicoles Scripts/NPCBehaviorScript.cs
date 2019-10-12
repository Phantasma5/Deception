using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCBehaviorScript : MonoBehaviour
{
    [SerializeField]
    private int startTalk;
    public string playerTalk;
    public Text textBox;
    // Start is called before the first frame update
    void Start()
    {
        startTalk = Random.Range(0, 2);
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

        StartCoroutine("PlayerIsSpeaking");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PlayerIsSpeaking()
    {
        textBox.text = playerTalk;
        Debug.Log(textBox.text);
        yield return new WaitForSeconds(5f);
        textBox.text = "";
    }
}

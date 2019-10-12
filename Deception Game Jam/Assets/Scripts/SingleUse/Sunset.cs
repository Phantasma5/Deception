using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunset : MonoBehaviour
{
    private GameManager instance;
    private float startTime;
    private void Start()
    {
        instance = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        startTime = instance.talkTimer;
    }
    private void Update()
    {
        if(instance.talkTimer > 0)
        {
            transform.Rotate(new Vector3(0.04f, 0, 0));
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameManager instance;
    private Vector3 modifier;
    [SerializeField] private float followDistance;
    [SerializeField] private float followHeight;
    [SerializeField] private float followSpeed;
    private void Start()
    {
        instance = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }
    private void Update()
    {
        //creating follow modifier
        modifier = instance.player.transform.forward * -followDistance;
        modifier.y = followHeight;

        transform.position = instance.player.transform.position + modifier;
        Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, transform.position, followSpeed);
        Camera.main.transform.LookAt(instance.player.transform.position);
    }
}

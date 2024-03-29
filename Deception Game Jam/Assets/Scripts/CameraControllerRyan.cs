﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerRyan : MonoBehaviour
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
        #region Camera should move faster if you're far away
        if (Vector3.Distance(Camera.main.transform.position, transform.position) > 5)
        {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, transform.position, followSpeed);
        }
        if (Vector3.Distance(Camera.main.transform.position, transform.position) > 10)
        {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, transform.position, followSpeed * 2);
        }
        if (Vector3.Distance(Camera.main.transform.position, transform.position) > 20)
        {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, transform.position, followSpeed * 5);
        }
        #endregion
        Camera.main.transform.LookAt(instance.player.transform.position);
    }
}

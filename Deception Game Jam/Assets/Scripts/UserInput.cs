using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    #region References
    private Rigidbody playerRigidbody;
    private GameManager instance;
    #endregion
    #region Variables
    [SerializeField] private float playerMovementSpeed;
    [SerializeField] private float turnSensitivity;
    #endregion
    private void Start()
    {
        instance = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        playerRigidbody = instance.player.GetComponent<Rigidbody>();
    }
    void Update()
    {
        Keypress();
        PlayerMovement();
    }
    void Keypress()
    {

    }
    void PlayerMovement()
    {
        //Mouse or Joystick Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 velX = instance.player.transform.right * horizontal;
        Vector3 velZ = instance.player.transform.forward * vertical;
        Vector3 vel = (velX + velZ).normalized * playerMovementSpeed;
        vel.y = playerRigidbody.velocity.y;
        playerRigidbody.velocity = vel;
        //Mouse Camera
        Vector3 rot;
        float mouseX = Input.GetAxis("Mouse X");
        rot = instance.player.transform.eulerAngles;
        rot.y += mouseX * turnSensitivity;
        instance.player.transform.eulerAngles = rot;
        //Joystick Camera
        float horizontal2 = Input.GetAxis("Horizontal2");
        float vertical2 = Input.GetAxis("Vertical2");
        rot = instance.player.transform.eulerAngles;
        rot.y += horizontal2;
        instance.player.transform.eulerAngles = rot;

    }
}

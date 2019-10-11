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
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 velX = instance.player.transform.right * horizontal;
        Vector3 velZ = instance.player.transform.forward * vertical;
        Vector3 vel = (velX + velZ).normalized * playerMovementSpeed;
        vel.y = playerRigidbody.velocity.y;
        playerRigidbody.velocity = vel;

        float mouseX = Input.GetAxis("Mouse X");
        Vector3 rot = instance.player.transform.eulerAngles;
        rot.y += mouseX * turnSensitivity;
        instance.player.transform.eulerAngles = rot;

    }
}

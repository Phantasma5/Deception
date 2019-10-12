using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    #region References
    private GameManager instance;
    #endregion
    #region Variables
    [SerializeField] private float playerMovementSpeed;
    [SerializeField] private float wolfSpeed;
    [SerializeField] private float turnSensitivity;
    [SerializeField] private float jumpForce;
    private GameObject hitbox;
    private int jumpCounter = 0;
    private float jumpCD;
    private RaycastHit targetHit;
    #endregion
    private void Start()
    {
        jumpCD = Time.time;
        instance = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }
    void Update()
    {
        Keypress();
        PlayerMovement();

        //get rid of hitbox
        if (null != hitbox)
        {
            Destroy(hitbox, 0.2f);
        }
    }
    void Keypress()
    {
        if (Input.GetButton("Jump") && instance.transformed)
        {
            Jump();
        }
        if (Input.GetButtonDown("Jump") && !instance.transformed)
        {
            //raycast if hit object has tag enemy
            if(Physics.Raycast(instance.player.transform.position, instance.player.transform.TransformDirection(Vector3.forward), out targetHit, 15f))
            {
                Debug.DrawLine(transform.position, transform.TransformDirection(Vector3.forward) * 15f, Color.red);
                Debug.Log("raycast shot");
                if(targetHit.collider.tag == "Enemy")
                {
                    Debug.Log("Target hit");
                    IEnumerator talkNow = targetHit.collider.gameObject.GetComponent<NPCBehaviorScript>().PlayerIsSpeaking();
                    StartCoroutine(talkNow);
                }
            }
        }
    }
    private void Jump()
    {
        if (jumpCD < Time.time)
        {
            hitbox = Attack();
            jumpCounter++;
            instance.player.GetComponent<Rigidbody>().AddForce((instance.player.transform.forward + new Vector3(0, 0.01f, 0)) * jumpForce);
            if (jumpCounter > 30)
            {
                jumpCD = Time.time + 1;
                jumpCounter = 0;
            }
        }
    }
    private GameObject Attack()
    {
        GameObject temp = Instantiate(instance.hixboxPrefab, (instance.player.transform.position + instance.player.transform.forward), instance.player.transform.rotation);
        return temp;
    }
    void PlayerMovement()
    {
        #region Mouse or Joystick Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 velX = instance.player.transform.right * horizontal;
        Vector3 velZ = instance.player.transform.forward * vertical;
        Vector3 vel;
        if (instance.transformed)
        {
            vel = (velX + velZ).normalized * wolfSpeed;
        }
        else
        {
            vel = (velX + velZ).normalized * playerMovementSpeed;
        }
        vel.y = instance.player.GetComponent<Rigidbody>().velocity.y;
        instance.player.GetComponent<Rigidbody>().velocity = vel;
        #endregion
        #region Mouse Camera
        Vector3 rot;
        float mouseX = Input.GetAxis("Mouse X");
        rot = instance.player.transform.eulerAngles;
        rot.y += mouseX * turnSensitivity;
        instance.player.transform.eulerAngles = rot;
        #endregion
        #region Joystick Camera
        float horizontal2 = Input.GetAxis("Horizontal2");
        float vertical2 = Input.GetAxis("Vertical2");
        rot = instance.player.transform.eulerAngles;
        rot.y += horizontal2;
        instance.player.transform.eulerAngles = rot;
        #endregion
    }
}

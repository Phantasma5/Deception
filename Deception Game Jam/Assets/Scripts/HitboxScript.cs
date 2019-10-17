using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxScript : MonoBehaviour
{
    private GameManager instance;

    private void Start()
    {
        instance = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }
    private void OnTriggerStay(Collider other)
    {
        if("Enemy" == other.gameObject.tag)
        {
            instance.score++;
            instance.myPersons.Remove(other.gameObject);
            Destroy(other.gameObject);
            instance.userScreen.UpdatePersonCount();
            instance.VictoryCheck();
        }
        Debug.Log(other.gameObject.tag);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxScript : MonoBehaviour
{
    public GameManager instance;
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("trigger entered");
        if("Enemy" == other.gameObject.tag)
        {
            Debug.Log("Enemy spotted");
            Destroy(other.gameObject);
            instance.userScreen.UpdatePersonCount();
        }
        Debug.Log(other.gameObject.tag);
    }
}

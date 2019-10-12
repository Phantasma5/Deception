using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxScript : MonoBehaviour
{
    public GameManager instance;
    private void OnTriggerStay(Collider other)
    {
        if("Enemy" == other.gameObject.tag)
        {
            instance.score++;
            Destroy(other.gameObject);
            instance.userScreen.UpdatePersonCount();
        }
        Debug.Log(other.gameObject.tag);
    }
}

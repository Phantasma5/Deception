using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if("Enemy" == other.gameObject.tag)
        {
            Destroy(other.gameObject);
        }
    }
}

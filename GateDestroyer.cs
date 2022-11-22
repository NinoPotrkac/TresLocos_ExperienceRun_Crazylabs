using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "destroy") // whent this game object colides with an object with the "destroy" tag
        {
            Destroy(this.gameObject); // this object is destroyed
        }
    }
}

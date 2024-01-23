using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_OpenGate : MonoBehaviour
{
    public Animator gateAnimation;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.tag == "ray") {
            gateAnimation.SetTrigger("Open");
        }
        
    }
}

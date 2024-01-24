using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_OpenPlatform : MonoBehaviour
{
    public Animator platformAnim;

    void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Player"))
        {
            platformAnim.SetTrigger("OpenPlatform");
        }
    }
}

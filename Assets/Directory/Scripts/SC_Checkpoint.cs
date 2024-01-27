using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Checkpoint : MonoBehaviour
{
    public SC_GameManager GM;
    
    void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GM.lastCheckPointPos = transform.position;
        }
    }
}

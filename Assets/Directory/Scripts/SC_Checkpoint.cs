using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Checkpoint : MonoBehaviour
{
    private SC_GameManager GM;
    
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<SC_GameManager>();
    }
    void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GM.lastCheckPointPos = transform.position;
        }
    }
}

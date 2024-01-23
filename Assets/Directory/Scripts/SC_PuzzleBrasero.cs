using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PuzzleBrasero : MonoBehaviour
{
    public bool rayEmitted = false;
    public GameObject mirrorRay;

    void Update()
    {
        if(rayEmitted==true)
        {
            mirrorRay.SetActive(true);
        }
        else
        {
            mirrorRay.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider raycollider)
    {
         if (raycollider.gameObject.tag == "ray") 
         {
            ReliableOnTriggerExit.NotifyTriggerEnter(raycollider, gameObject, OnTriggerExit);
        rayEmitted=true;
        }
        
    }
    private void OnTriggerExit(Collider raycollider)
    {
        if (raycollider.gameObject.tag == "ray")
        {
        ReliableOnTriggerExit.NotifyTriggerExit(raycollider, gameObject);
        rayEmitted=false;
        }
    }
}

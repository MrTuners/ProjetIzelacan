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

    private void OnTriggerEnter(Collider other)
    {
        ReliableOnTriggerExit.NotifyTriggerEnter(other, gameObject, OnTriggerExit);
        rayEmitted=true;
    }
    private void OnTriggerExit(Collider other)
    {
        ReliableOnTriggerExit.NotifyTriggerExit(other, gameObject);
        rayEmitted=false;
    }
}

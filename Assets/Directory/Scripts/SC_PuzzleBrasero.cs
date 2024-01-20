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

    private void OnTriggerEnter(Collider ray)
    {
        ReliableOnTriggerExit.NotifyTriggerEnter(ray, gameObject, OnTriggerExit);
        rayEmitted=true;
    }
    private void OnTriggerExit(Collider ray)
    {
        ReliableOnTriggerExit.NotifyTriggerExit(ray, gameObject);
        rayEmitted=false;
    }
}

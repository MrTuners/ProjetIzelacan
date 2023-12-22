using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_PlayerRaycast : MonoBehaviour
{
    public LayerMask layerMask;
    public GameObject textMove;
    public bool canMove;
   void FixedUpdate()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5, layerMask))
        {
            textMove.SetActive(true);
            canMove=true;
        }
        else
        {
            textMove.SetActive(false);
            canMove=false;
        }
    }
}

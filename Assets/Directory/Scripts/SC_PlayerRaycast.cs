using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_PlayerRaycast : MonoBehaviour
{
    public LayerMask blocMask;
    public LayerMask diskMask;
    public GameObject textMove;
    public GameObject diskText;
    public bool canMove;
    public bool enterDisk;

    RaycastHit hit;

   void FixedUpdate()
    {
        
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5, blocMask))
        {
            textMove.SetActive(true);
            canMove=true;
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5, diskMask))
        {
            diskText.SetActive(true);
            enterDisk=true;
        }
        else
        {
            diskText.SetActive(false);
            enterDisk=false;
            textMove.SetActive(false);
            canMove=false;
        }
    }

    public bool BlocCanMove(GameObject bloc)
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5, blocMask))
        {
            if(hit.transform.gameObject == bloc) return true;
            else return false;
            
        }
        else
        {
            return false;
        }
    }
}

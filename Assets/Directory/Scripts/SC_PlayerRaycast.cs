using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_PlayerRaycast : MonoBehaviour
{
    public LayerMask blocMask;
    public LayerMask lunarMask;
    public LayerMask solarMask;
    public LayerMask endMask;
    public GameObject textMove;
    public GameObject diskText;
    public GameObject endText;
    public bool canMove;
    public bool enterLdisk;
    public bool enterSdisk;
    public bool canEnd;

    RaycastHit hit;

   void FixedUpdate()
    {
        
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5, blocMask))
        {
            textMove.SetActive(true);
            canMove=true;
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5, lunarMask))
        {
            diskText.SetActive(true);
            enterLdisk=true;
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5, solarMask))
        {
            diskText.SetActive(true);
            enterSdisk=true;
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5, endMask))
        {
            endText.SetActive(true);
            canEnd=true;
        }
        else
        {
            endText.SetActive(false);
            diskText.SetActive(false);
            enterLdisk=false;
            enterSdisk=false;
            textMove.SetActive(false);
            canMove=false;
            canEnd=false;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_BraseroMove : MonoBehaviour
{
    public SC_PlayerRaycast raycastScript;
    public bool blocMovable = false;
    public GameObject blocObject;
    public Vector3 originPosition;
    public Vector3 targetPosition;

    void Start()
    {
        originPosition = transform.position;
        targetPosition = originPosition;
    }

    void Update()
    {
        if(raycastScript.canMove==true)
        {
            blocMovable=true;
        } else if(raycastScript.canMove==false)
        {
            blocMovable=false;
        }

        if(blocMovable==true)
        {
            MoveBloc();
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
        
    }

    private void MoveBloc()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            //blocObject.transform.position = blocObject.transform.position + new Vector3(3,0,0);
            targetPosition = targetPosition + new Vector3(2.5f, 0, 0);
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
            //blocObject.transform.position = blocObject.transform.position + new Vector3(3,0,0);
            targetPosition = targetPosition + new Vector3(-2.5f, 0, 0);
        }
    }
}

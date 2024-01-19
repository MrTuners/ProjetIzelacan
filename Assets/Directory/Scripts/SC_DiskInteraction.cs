using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_DiskInteraction : MonoBehaviour
{
    public SC_PlayerRaycast raycastScript;
    public FirstPersonController playerScript;
    public Camera playerCamera;
    public GameObject diskCamera;
    public bool solvingDisk = false;
    public bool canSolve = false;

    // Update is called once per frame
    void Update()
    {
        if(solvingDisk==false && raycastScript.enterDisk==true && Input.GetKeyDown(KeyCode.F))
        {
            canSolve = true;
        }
        if(canSolve==true)
        {
            StartPuzzle();
        }
        if(solvingDisk==true && Input.GetKeyDown(KeyCode.F))
        {
            playerScript.canMove=true;
        diskCamera.SetActive(false);
        playerCamera.enabled=true;
        solvingDisk=false;
        }
    }

    public void StartPuzzle()
    {
        playerScript.canMove=false;
        diskCamera.SetActive(true);
        playerCamera.enabled=false;
        solvingDisk=true;
    }
}

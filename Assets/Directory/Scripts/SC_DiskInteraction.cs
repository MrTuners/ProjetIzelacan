using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_DiskInteraction : MonoBehaviour
{
    public SC_PlayerRaycast raycastScript;
    public FirstPersonController playerScript;
    public SC_LunarDisk lunarScript;
    public SC_SolarDisk solarScript;
    public Camera playerCamera;
    public GameObject lunarCamera;
    public GameObject solarCamera;
    public bool solvingDisk = false;
    public bool openGate = false;
    public Animator gateAnimation;

    // Update is called once per frame
    void Update()
    {
        if(lunarScript.diskLDone==true && solarScript.diskSDone==true)
        {
            OpenGate();
        }

        if(raycastScript.enterLdisk==true && Input.GetKeyDown(KeyCode.F))
        {
            StartLunarPuzzle();
        }
        else if (raycastScript.enterSdisk==true && Input.GetKeyDown(KeyCode.F))
        {
            StartSolarPuzzle();
        }

        if(lunarScript.diskLDone==true)
        {
            playerScript.canMove=true;
            playerCamera.enabled=true;
        lunarCamera.SetActive(false);
        solvingDisk=false;
        }

        if(solarScript.diskSDone==true)
        {
            playerScript.canMove=true;
            playerCamera.enabled=true;
        solarCamera.SetActive(false);
        solvingDisk=false;
        }
    }

    public void StartLunarPuzzle()
    {
        playerScript.canMove=false;
        playerCamera.enabled=false;
        lunarCamera.SetActive(true);
        solvingDisk=true;
    }
    public void StartSolarPuzzle()
    {
        playerScript.canMove=false;
        playerCamera.enabled=false;
        solarCamera.SetActive(true);
        solvingDisk=true;
    }

    public void OpenGate()
    {
        gateAnimation.SetTrigger("GateTrigger");
    }
}

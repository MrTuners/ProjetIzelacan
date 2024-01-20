using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_DiskInteraction : MonoBehaviour
{
    public SC_PlayerRaycast raycastScript;
    public FirstPersonController playerScript;
    public SC_LunarDisk lunarScript;
    public SC_SolarDisk solarScript;
    public GameObject playerCamera;
    public GameObject lunarCamera;
    public GameObject solarCamera;
    public bool solvingLunar = false;
    public bool solvingSolar = false;
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

        if (raycastScript.enterSdisk==true && Input.GetKeyDown(KeyCode.F))
        {
            StartSolarPuzzle();
        }

        if(solvingLunar==true && Input.GetKeyDown(KeyCode.Escape))
        {
            playerScript.canMove=true;
        playerCamera.SetActive(true);
        lunarCamera.SetActive(false);
        solvingLunar=false;
        }
        if(solvingSolar==true && Input.GetKeyDown(KeyCode.Escape))
        {
            playerScript.canMove=true;
        playerCamera.SetActive(true);
        solarCamera.SetActive(false);
        solvingSolar=false;
        }
    }

    public void StartLunarPuzzle()
    {
        playerScript.canMove=false;
        playerCamera.SetActive(false);
        lunarCamera.SetActive(true);
        solvingLunar=true;
    }
    public void StartSolarPuzzle()
    {
        playerScript.canMove=false;
        playerCamera.SetActive(false);
        solarCamera.SetActive(true);
        solvingSolar=true;
    }

    public void OpenGate()
    {
        gateAnimation.SetTrigger("GateTrigger");
        playerScript.canMove=true;
        playerCamera.SetActive(true);
        solarCamera.SetActive(false);
        lunarCamera.SetActive(false);
        solvingSolar=false;
        solvingLunar=false;
    }
}

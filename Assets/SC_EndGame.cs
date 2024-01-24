using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_EndGame : MonoBehaviour
{
    public SC_LavaBehavior lavaScript;
    public SC_PlayerRaycast raycastScript;
    public GameObject endCamera;
    public GameObject playerCamera;
    public FirstPersonController playersScript;
    public Animator gateAnim;
    public Animator pillarAnim;
    public GameObject blockBridge;
    public bool cinematicPlaying=false;
    public float countdownCinematic = 4f;

    // Update is called once per frame
    void Update()
    {
        if(raycastScript.canEnd==true && Input.GetKeyDown(KeyCode.F))
        {
            cinematicPlaying=true;
            playerCamera.SetActive(false);
            playersScript.canMove=false;
            lavaScript.endGame=true;
            endCamera.SetActive(true);
            gateAnim.SetTrigger("EndOpen");
            pillarAnim.SetTrigger("PillarFall");
        }
        if(cinematicPlaying==true)
        {
            countdownCinematic -= Time.deltaTime;
        }
        if(countdownCinematic<0f)
        {
            cinematicPlaying=false;
            playerCamera.SetActive(true);
            playersScript.canMove=true;
            endCamera.SetActive(false);
        }
    }
}

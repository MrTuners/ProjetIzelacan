using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_PlayerDeath : MonoBehaviour
{
    public SC_DartsTrap dartsScript;
    public SC_GameManager GMscript;
    public GameObject deathScreen;
    public FirstPersonController playerScript;
    public Transform lavaPos;
    private void OnTriggerEnter(Collider Player)
{
    if (Player.gameObject.CompareTag("Darts"))
    {
        DeathScreen();
    } else if (Player.gameObject.CompareTag("Axe"))
    {
        DeathScreen();
    } else if (Player.gameObject.CompareTag("lavaBlock"))
    {
        DeathScreen();
    }else if (Player.gameObject.CompareTag("Plate"))
    {
        dartsScript.DartFires();
    }
}

private void DeathScreen()
{
    Cursor.visible=true;
    Cursor.lockState=CursorLockMode.None;
    playerScript.canMove=false;
    deathScreen.SetActive(true);
}

public void RetryButton()
{
    lavaPos.position = new Vector3(-82.75f,-74.3f,0f);
    transform.position = GMscript.lastCheckPointPos;
    Cursor.visible=false;
    Cursor.lockState=CursorLockMode.Locked;
    playerScript.canMove=true;
    deathScreen.SetActive(false);
}

public void QuitButton()
{
    Application.Quit();
}
}

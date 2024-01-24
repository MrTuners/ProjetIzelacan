using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_PlayerDeath : MonoBehaviour
{
    public SC_DartsTrap dartsScript;
    public GameObject deathScreen;
    public FirstPersonController playerScript;
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
    SceneManager.LoadScene("Test_BlockoutRayan");
}

public void QuitButton()
{
    Application.Quit();
}
}

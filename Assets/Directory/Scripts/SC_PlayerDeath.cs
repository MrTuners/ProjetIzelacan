using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_PlayerDeath : MonoBehaviour
{
    public SC_DartsTrap dartsScript;
    private void OnTriggerEnter(Collider Player)
{
    if (Player.gameObject.CompareTag("Darts"))
    {
        SceneManager.LoadScene("Test_Blockout");
    } else if (Player.gameObject.CompareTag("Axe"))
    {
        SceneManager.LoadScene("Test_Blockout");
    } else if (Player.gameObject.CompareTag("Plate"))
    {
        dartsScript.DartFires();
    }
}
}

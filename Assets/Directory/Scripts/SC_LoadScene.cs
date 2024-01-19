using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SC_LoadScene : MonoBehaviour
{
    public GameObject creditPanel;
    public void LoadScene(string Scene_Name)
    {
        SceneManager.LoadScene(Scene_Name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void CreditsButton()
    {
        creditPanel.SetActive(true);
    }
    public void LeaveCredits()
    {
        creditPanel.SetActive(false);
    }

}

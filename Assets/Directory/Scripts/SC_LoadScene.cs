using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SC_LoadScene : MonoBehaviour
{
    public void LoadScene(string Scene_Name)
    {
        SceneManager.LoadScene(Scene_Name);
    }
}

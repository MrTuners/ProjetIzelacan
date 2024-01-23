using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SC_PauseMenu : MonoBehaviour
{
    [SerializeField] private KeyCode pauseKey;
    public string sceneName;
    public GameObject pauseMenu;
    public FirstPersonController playerScript;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            GamePause();
        }
    }

    private void GamePause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        playerScript.lockLook=true;
        Time.timeScale=0f;
        pauseMenu.SetActive(true);
    }

    public void UnpauseGame()
    {
        Cursor.visible = false;
        playerScript.lockLook=false;
        Time.timeScale=1f;
        pauseMenu.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

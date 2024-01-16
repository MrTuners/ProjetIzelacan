using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public string LevelToLoad;

    void LoadMenu () {
        SceneManager.LoadScene("MainMenu");
      }

    void LoadLevel()
    {
        SceneManager.LoadScene(LevelToLoad);
    }

}
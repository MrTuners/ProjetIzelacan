using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SC_LoadingScreen : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Image LoadingBarFill;
    public int sceneId;

    private void OnTriggerEnter(Collider Player)
    {
        LoadScene();
    }

    public void LoadScene()
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        LoadingScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        while (!operation.isDone)
        {
            float progressValue=Mathf.Clamp01(operation.progress/0.9f);

            LoadingBarFill.fillAmount=progressValue;

            yield return null;
        }
    }
}

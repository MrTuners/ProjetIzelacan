using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_SceneSwap : MonoBehaviour
{
    public string sceneToSwap;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadSceneAsync(sceneToSwap);
    }

    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(sceneToSwap);
    }
}

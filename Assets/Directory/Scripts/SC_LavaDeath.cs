using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_LavaDeath : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider lavaBlock)
    {
        SceneManager.LoadScene("Test_Blockout");
    }
}

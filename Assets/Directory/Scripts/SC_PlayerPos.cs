using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_PlayerPos : MonoBehaviour
{
    public SC_GameManager GM;

    void Start()
    {
        transform.position = GM.lastCheckPointPos;
    }

    //void Update()
    //{
     //   if(Input.GetKeyDown(KeyCode.Space))
     //   {
     //       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     //   }
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_PlayerPos : MonoBehaviour
{
    private SC_GameManager GM;

    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<SC_GameManager>();
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

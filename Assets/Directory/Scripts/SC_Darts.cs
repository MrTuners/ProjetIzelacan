using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_Darts : MonoBehaviour
{
    public float movementSpeed = 20;
    void Update()
    {
        this.transform.position = this.transform.position + new Vector3(0,0,movementSpeed*Time.deltaTime);
    }
}
    

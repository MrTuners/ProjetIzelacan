using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_LavaBehavior : MonoBehaviour
{
    public GameObject lavaObject;
    public bool endGame = false;

    void Update()
    {
        if(endGame==true)
        {
        lavaObject.transform.position = lavaObject.transform.position + new Vector3(0,1*Time.deltaTime,0);
        }
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider lavaTrigger)
    {
        endGame = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Finish : MonoBehaviour
{
    public GameObject EGPanel;
    private void OnTriggerEnter(Collider other)
    {
    if(other.CompareTag("Player"))
        {
            Time.timeScale=0f;
            EGPanel.SetActive(true);
        }
    }
}

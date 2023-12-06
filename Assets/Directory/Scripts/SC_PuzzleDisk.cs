using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PuzzleDisk : MonoBehaviour
{
    public bool inZone = false;
    public GameObject puzzlePanel;
    public GameObject cameraPlayer;
    public GameObject cameraPuzzle;

    // Update is called once per frame
    void Update()
    {
        if(inZone==true&&Input.GetKeyDown(KeyCode.F))
        {
            puzzlePanel.SetActive(true);
            cameraPlayer.SetActive(false);
            cameraPuzzle.SetActive(true);
            Cursor.visible=true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            puzzlePanel.SetActive(false);
            cameraPlayer.SetActive(true);
            cameraPuzzle.SetActive(false);
            Cursor.visible=false;
        }
    }

    private void OnTriggerEnter(Collider PuzzleZone)
    {
        inZone = true;
    }
    private void OnTriggerExit(Collider PuzzleZone)
    {
        inZone = false;
    }
}

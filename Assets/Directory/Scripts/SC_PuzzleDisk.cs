using UnityEngine;
using UnityEngine.UI;

public class SC_PuzzleDisk : MonoBehaviour
{
    public Vector3 currentAngle;
    public SC_DiskInteraction diskScript;
    public Transform[] rays;
    public GameObject[] indicatorCubes;
    public float rotationAmount = -90f;
    public bool diskDone = false;

    private int currentIndex = 0;
    public Quaternion[] targetRotation;

    void Start()
    {
        UpdateIndicator();
        targetRotation=new Quaternion[3];
        currentAngle = new Vector3(0,0,0);
        targetRotation[0] = Quaternion.Euler(0,90,0);
        targetRotation[1] = Quaternion.Euler(0,180,0);
        targetRotation[2] = Quaternion.Euler(0,270,0);
    }

    void Update()
    {
        DiskCompletion();
        if(diskScript.solvingDisk==true && !diskDone==true)
        {
            HandleInput();
        }
        for(int i=0; i<rays.Length; i++)
            {
             rays[i].localRotation = Quaternion.Lerp(rays[i].localRotation, targetRotation[i],Time.deltaTime*5);
            }
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SelectNextRay();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SelectPreviousRay();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RotateCurrentRay(-rotationAmount);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RotateCurrentRay(rotationAmount);
        }

        UpdateIndicator();
    }

    void RotateCurrentRay(float rotationAmount)
    {
        currentAngle = currentAngle + new Vector3(0,rotationAmount,0);
        targetRotation[currentIndex] = Quaternion.Euler(currentAngle);
    }

    void SelectNextRay()
    {
        currentIndex = (currentIndex + 1) % rays.Length;
    }

    void SelectPreviousRay()
    {
        currentIndex = (currentIndex - 1 + rays.Length) % rays.Length;
    }

    void DiskCompletion()
    {
        if(targetRotation[0]==Quaternion.Euler(0,90,0) && targetRotation[1] == Quaternion.Euler(0,180,0) && targetRotation[2] == Quaternion.Euler(0,270,0))
        {
            diskDone=true;
        }
        else
        {
            diskDone=false;
        }
    }

    void UpdateIndicator()
    {
        foreach (var cube in indicatorCubes)
        {
            cube.SetActive(false);
        }

        if (currentIndex < indicatorCubes.Length)
        {
            indicatorCubes[currentIndex].SetActive(true);
        }
    }
}

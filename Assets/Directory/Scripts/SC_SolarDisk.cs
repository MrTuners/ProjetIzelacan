using UnityEngine;
using UnityEngine.UI;

public class SC_SolarDisk : MonoBehaviour
{
    public Vector3 currentAngle1;
    public SC_DiskInteraction diskScript;
    public Transform[] rays1;
    public GameObject[] indicatorCubes1;
    public float rotationAmount1 = -90f;
    public bool diskSDone;
    private int currentIndex1 = 0;
    public  Quaternion[] targetRotation1;

    void Start()
    {
        diskSDone = false;
        UpdateIndicator();
        targetRotation1=new Quaternion[4];
        currentAngle1 = new Vector3(0,0,0);
        targetRotation1[0] = Quaternion.Euler(0,90,0);
        targetRotation1[1] = Quaternion.Euler(0,180,0);
        targetRotation1[2] = Quaternion.Euler(0,270,0);
        targetRotation1[3] = Quaternion.Euler(0,180,0);
    }

    void Update()
    {
        DiskCompletion();
        
        if(diskScript.solvingSolar==true && !diskSDone==true)
        {
            HandleInput();
        }
        for(int i=0; i<rays1.Length; i++)
        {
             rays1[i].localRotation = Quaternion.Lerp(rays1[i].localRotation, targetRotation1[i],Time.deltaTime*5);
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
            RotateCurrentRay(-rotationAmount1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RotateCurrentRay(rotationAmount1);
        }

        UpdateIndicator();
    }

    void RotateCurrentRay(float rotationAmount1)
    {
        currentAngle1 = currentAngle1 + new Vector3(0,rotationAmount1,0);
        targetRotation1[currentIndex1] = Quaternion.Euler(currentAngle1);
    }

    void SelectNextRay()
    {
        currentIndex1 = (currentIndex1 + 1) % rays1.Length;
    }

    void SelectPreviousRay()
    {
        currentIndex1 = (currentIndex1 - 1 + rays1.Length) % rays1.Length;
    }

    void DiskCompletion()
    {
        if(CheckRange(targetRotation1[0].eulerAngles.y, 0f, 10f) && CheckRange(targetRotation1[1].eulerAngles.y, 0f, 10f) && CheckRange(targetRotation1[2].eulerAngles.y, 0f, 10f) && CheckRange(targetRotation1[3].eulerAngles.y, 0f, 10f))
        {
            diskSDone=true;
        }
        else
        {
            diskSDone=false;
        }
    }

    private bool CheckRange (float eulerAngles, float targetAngle, float range)
{
    return (eulerAngles > targetAngle - range && eulerAngles < targetAngle + range);
}

    void UpdateIndicator()
    {
        foreach (var cube in indicatorCubes1)
        {
            cube.SetActive(false);
        }

        if (currentIndex1 < indicatorCubes1.Length)
        {
            indicatorCubes1[currentIndex1].SetActive(true);
        }
    }
}

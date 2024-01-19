using UnityEngine;
using UnityEngine.UI;

public class SC_SolarDisk : MonoBehaviour
{
    public Vector3 currentAngle;
    public SC_DiskInteraction diskScript;
    public Transform[] rays;
    public GameObject[] indicatorCubes;
    public float rotationAmount = -90f;
    public bool diskSDone = false;
    private int currentIndex = 0;
    public  Quaternion[] targetRotation1;

    void Start()
    {
        UpdateIndicator();
        targetRotation1=new Quaternion[4];
        currentAngle = new Vector3(0,0,0);
        targetRotation1[0] = Quaternion.Euler(0,90,0);
        targetRotation1[1] = Quaternion.Euler(0,180,0);
        targetRotation1[2] = Quaternion.Euler(0,270,0);
        targetRotation1[3] = Quaternion.Euler(0,180,0);
    }

    void Update()
    {
        DiskCompletion();
        
        if(diskScript.solvingDisk==true && !diskSDone==true)
        {
            HandleInput();
        }
        for(int i=0; i<rays.Length; i++)
        {
             rays[i].localRotation = Quaternion.Lerp(rays[i].localRotation, targetRotation1[i],Time.deltaTime*5);
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
        targetRotation1[currentIndex] = Quaternion.Euler(currentAngle);
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

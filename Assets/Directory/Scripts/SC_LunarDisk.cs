using UnityEngine;
using UnityEngine.UI;

public class SC_LunarDisk : MonoBehaviour
{
    public Vector3 currentAngle;
    public SC_DiskInteraction diskScript;
    public Transform[] rays;
    public GameObject[] indicatorCubes;
    public float rotationAmount = -90f;
    public bool diskLDone;
    private int currentIndex = 0;
    public  Quaternion[] targetRotation;

    void Start()
    {
        diskLDone = false;
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
        
        if(diskScript.solvingLunar==true && !diskLDone==true)
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
        if(CheckRange(targetRotation[0].eulerAngles.y, 0f, 10f) && CheckRange(targetRotation[1].eulerAngles.y, 0f, 10f) && CheckRange(targetRotation[2].eulerAngles.y, 0f, 10f))
        {
            diskLDone=true;
        }
        else
        {
            diskLDone=false;
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

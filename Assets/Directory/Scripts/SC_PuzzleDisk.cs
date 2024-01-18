using UnityEngine;
using UnityEngine.UI;

public class SC_PuzzleDisk : MonoBehaviour
{
    public Transform[] rays;
    public GameObject[] indicatorCubes; // Cube objects associated with each ray
    public float rotationAmount = -90f;

    private int currentIndex = 0;

    void Start()
    {
        UpdateIndicator();
    }

    void Update()
    {
        HandleInput();
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
        rays[currentIndex].localRotation = Quaternion.Euler(rotationAmount,0f,0f);
    }

    void SelectNextRay()
    {
        currentIndex = (currentIndex + 1) % rays.Length;
    }

    void SelectPreviousRay()
    {
        currentIndex = (currentIndex - 1 + rays.Length) % rays.Length;
    }

    void UpdateIndicator()
    {
        // Disable all indicator cubes
        foreach (var cube in indicatorCubes)
        {
            cube.SetActive(false);
        }

        // Enable the indicator cube for the current ray
        if (currentIndex < indicatorCubes.Length)
        {
            indicatorCubes[currentIndex].SetActive(true);
        }
    }
}

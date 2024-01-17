using UnityEngine;
using UnityEngine.UI;

public class SC_PuzzleDisk : MonoBehaviour
{
    public Transform[] rays;
    public GameObject[] indicatorCubes; // Cube objects associated with each ray
    public float rotationAmount = 90f; // Defined rotation amount

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
            RotateCurrentRay(-rotationAmount); // Rotate left by a continuous speed
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RotateCurrentRay(rotationAmount); // Rotate right by a continuous speed
        }

        UpdateIndicator();
    }

    void RotateCurrentRay(float amount)
    {
        rays[currentIndex].Rotate(Vector3.right, amount);
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

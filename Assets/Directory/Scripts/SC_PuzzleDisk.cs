using UnityEngine;
using UnityEngine.UI;

public class SC_PuzzleDisk : MonoBehaviour
{
    public RectTransform[] rays;
    public GameObject[] indicatorCubes; // Cube objects associated with each ray
    public float rotationSpeed = 5f;
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
            RotateCurrentRay(-rotationSpeed); // Rotate left by a continuous speed
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RotateCurrentRay(rotationSpeed); // Rotate right by a continuous speed
        }

        UpdateIndicator();
    }

    void RotateCurrentRay(float amount)
    {
        rays[currentIndex].Rotate(Vector3.forward, amount);
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

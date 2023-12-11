using UnityEngine;

public class SC_ForceZone : MonoBehaviour
{
    private CharacterController characterController;
    private bool isInsideCollider = false;

    public float upwardForce = 50f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (isInsideCollider)
        {
            // Apply upward force
            Vector3 force = Vector3.up * upwardForce * Time.deltaTime;
            characterController.Move(force);
        }
    }
}

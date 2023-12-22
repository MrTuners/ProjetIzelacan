using UnityEngine;

public class SC_ForceZone : MonoBehaviour
{
    public float upwardSpeed = 5f; // Adjust this value based on the desired speed
    private CharacterController characterController;

    private void OnTriggerStay(Collider other)
    {
        ApplyUpwardEffect(other.gameObject);
    }

    private void ApplyUpwardEffect(GameObject target)
    {
        if (characterController == null)
        {
            characterController = target.GetComponent<CharacterController>();
            if (characterController == null)
            {
                Debug.LogError("UpdraftZone requires a CharacterController on the target object.");
                return;
            }
        }

        // Ensure that the player is grounded before applying upward force
        if (characterController.isGrounded)
        {
            Vector3 verticalMovement = Vector3.up * upwardSpeed * Time.deltaTime;

            // Apply a constant upward force while inside the trigger zone
            characterController.Move(verticalMovement);
        }
    }
}

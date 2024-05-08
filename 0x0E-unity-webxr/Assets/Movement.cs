using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5.0f; // Movement speed
    public float grabRange = 2.0f; // The range within which objects can be grabbed
    private GameObject grabbedObject; // Reference to the currently grabbed object
    public Transform cameraTransform; // Reference to the main camera's transform

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction based on camera orientation
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0f; // Keep movement in the horizontal plane
        right.y = 0f;   // Keep movement in the horizontal plane
        forward.Normalize();
        right.Normalize();
        
        // Calculate movement direction
        Vector3 moveDirection = forward * verticalInput + right * horizontalInput;

        // Move the character
        controller.Move(moveDirection * speed * Time.deltaTime);

        // Check for grab input
        if (Input.GetMouseButtonDown(0)) // Assuming left mouse button for grab action
        {
            if (grabbedObject == null)
            {
                // Try to grab an object if one is within range
                GrabObject();
            }
            else
            {
                // Drop the currently grabbed object
                DropObject();
            }
        }
    }

    void GrabObject()
    {
        // Cast a ray from the character's position forward to detect objects within range
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, grabRange))
        {
            // Check if the hit object is interactable
            InteractableObject interactable = hit.collider.GetComponent<InteractableObject>();
            if (interactable != null)
            {
                // Grab the object
                grabbedObject = interactable.gameObject;
                interactable.Grab(transform);
            }
        }
    }

    void DropObject()
{
    // Check if there's a grabbed object
    if (grabbedObject != null)
    {
        // Drop the object
        InteractableObject interactable = grabbedObject.GetComponent<InteractableObject>();
        if (interactable != null)
        {
            interactable.Drop();

            // Calculate the direction to throw the ball (forward relative to the camera)
            Vector3 throwDirection = cameraTransform.forward;

            // Calculate the throw force based on the distance from the player to the ball
            float throwForce = Vector3.Distance(grabbedObject.transform.position, transform.position);

            // Apply force to the ball in the calculated direction and with the calculated force
            Rigidbody rb = grabbedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
            }

            grabbedObject = null;
        }
    }
}
}
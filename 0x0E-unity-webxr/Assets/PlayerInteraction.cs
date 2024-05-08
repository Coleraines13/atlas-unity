using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 3f; // Range for raycasting to detect objects
    public LayerMask interactionMask; // Layer mask for objects that can be interacted with

    void Update()
    {
        // this check's for interaction input
        if (Input.GetMouseButtonDown(0)) // Example: Left mouse button for interaction
        {
            // this cast's a ray from the center of the screen
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

            RaycastHit hit;
            // this check's if the ray hits an object within the interaction range
            if (Physics.Raycast(ray, out hit, interactionRange, interactionMask))
            {
                // this call's the Interact method on the hit object
                hit.transform.GetComponent<InteractableObject>()?.Interact();
            }
        }
    }
}
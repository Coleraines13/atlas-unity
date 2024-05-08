using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        // Ensure the object has a Rigidbody component for physics interactions
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true; // Make the Rigidbody kinematic to prevent physics from affecting it until grabbed
        }
    }

    public void Grab(Transform parent)
    {
        // Parent the object to the cursor or capsule (or any other parent) when grabbed
        transform.SetParent(parent);
        rb.isKinematic = true; // Make the Rigidbody kinematic to prevent physics from affecting it while held
    }

    public void Drop()
    {
        // Release the object when dropped
        transform.SetParent(null);
        rb.isKinematic = false; // Make the Rigidbody non-kinematic to allow physics to affect it again
    }

    public void Interact()
    {
        // Define interaction behavior here
        Debug.Log("Interacting with object: " + gameObject.name);
    }
}
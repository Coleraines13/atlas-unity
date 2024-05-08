using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5.0f; // Movement speed
    public float horizontalLimit = 5.0f; // Horizontal movement limit

    void Update()
    {
        // Get input for horizontal movement (left and right)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate movement direction
        Vector3 moveDirection = Vector3.right * horizontalInput;

        // Calculate next position based on movement direction
        Vector3 nextPosition = transform.position + moveDirection * speed * Time.deltaTime;

        // Clamp next position within horizontal limits
        nextPosition.x = Mathf.Clamp(nextPosition.x, -horizontalLimit, horizontalLimit);

        // Move the ball
        transform.position = nextPosition;
    }
}
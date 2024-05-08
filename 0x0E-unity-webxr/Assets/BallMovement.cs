using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5.0f; // Movement speed
    public float horizontalLimit = 5.0f; // Horizontal movement limit

    void Update()
    {
        // this get's input for horizontal movement (left and right)
        float horizontalInput = Input.GetAxis("Horizontal");

        // calculate's movement direction
        Vector3 moveDirection = Vector3.right * horizontalInput;

        // calculate's next position based on movement direction
        Vector3 nextPosition = transform.position + moveDirection * speed * Time.deltaTime;

        // clamp's the next position within horizontal limits
        nextPosition.x = Mathf.Clamp(nextPosition.x, -horizontalLimit, horizontalLimit);

        // move's the ball
        transform.position = nextPosition;
    }
}
using UnityEngine;

public class ControlSwitcher : MonoBehaviour
{
    public GameObject capsule; // Reference to the capsule GameObject
    public GameObject ball; // Reference to the ball GameObject
    public GameObject capsuleCamera; // Reference to the capsule camera GameObject
    public GameObject ballCamera; // Reference to the ball camera GameObject

    private CapsuleMovement capsuleMovementScript;
    private BallMovement ballMovementScript;

    private bool ballThrown = false; // Flag to indicate if the ball has been thrown

    void Start()
    {
        // Get references to movement scripts
        capsuleMovementScript = capsule.GetComponent<CapsuleMovement>();
        ballMovementScript = ball.GetComponent<BallMovement>();

        // Disable ball camera at the start
        ballCamera.SetActive(false);
    }

    void Update()
    {
        // Condition to check if the ball is thrown
        if (Input.GetKeyDown(KeyCode.Space) && !ballThrown)
        {
            // Disable capsule controls and camera
            capsuleMovementScript.enabled = false;
            capsuleCamera.SetActive(false);

            // Enable ball controls and camera
            ballMovementScript.enabled = true;
            ballCamera.SetActive(true);

            // Set ball camera position and rotation relative to the ball
            ballCamera.transform.SetParent(ball.transform);
            ballCamera.transform.localPosition = Vector3.zero; // Adjust as needed
            ballCamera.transform.localRotation = Quaternion.identity; // Adjust as needed

            // Set flag to indicate the ball has been thrown
            ballThrown = true;
        }
        // Condition to switch back to capsule (e.g., after the ball falls into the pit or stops moving)
        else if (ball.GetComponent<Rigidbody>().velocity.magnitude < 0.1f && ballThrown)
        {
            // Disable ball controls and camera
            ballMovementScript.enabled = false;
            ballCamera.SetActive(false);

            // Enable capsule controls and camera
            capsuleMovementScript.enabled = true;
            capsuleCamera.SetActive(true);

            // Reset flag
            ballThrown = false;
        }
    }
}
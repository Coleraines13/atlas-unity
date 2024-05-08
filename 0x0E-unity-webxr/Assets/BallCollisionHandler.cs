using UnityEngine;

public class BallCollisionHandler : MonoBehaviour
{
    public BowlingScoreManager scoreManager; // Reference to the BowlingScoreManager component

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("pins"))
        {
            // Call PinHit method of the BowlingScoreManager to increment the score
            scoreManager.PinHit();
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

public class BowlingScoreManager : MonoBehaviour
{
    public Text scoreText; // Reference to the UI Text component to display the score
    private int score = 0; // Player's score

    void Start()
    {
        // Initialize score text
        UpdateScoreText();
    }

    // Called when a pin is hit
    public void PinHit()
    {
        // Increment the score by 1 for each pin hit
        score += 1;
        UpdateScoreText();
    }

    // Update the score text on the UI
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString(); // Update the UI Text component with the current score
    }
}
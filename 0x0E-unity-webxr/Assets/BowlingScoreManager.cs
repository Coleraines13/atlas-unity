using UnityEngine;
using UnityEngine.UI;

public class BowlingScoreManager : MonoBehaviour
{
    public Text scoreText; // this is the reference to the UI Text component to display the score
    private int score = 0; // player's score

    void Start()
    {
        // starts the score text
        UpdateScoreText();
    }

    // called when a pin is hit
    public void PinHit()
    {
        // this increment's the score by 1 for each pin hit
        score += 1;
        UpdateScoreText();
    }

    // this update's the score text on the UI
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString(); // Update the UI Text component with the current score
    }
}
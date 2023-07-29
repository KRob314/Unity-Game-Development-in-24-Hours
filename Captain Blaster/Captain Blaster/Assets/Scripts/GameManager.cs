using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text gameOverText;
    int playerScore = 0;
    public void AddScore()
    {
        playerScore++;
        // This converts the score (a number) into a string
        scoreText.text = playerScore.ToString();
    }
    public void PlayerDied()
    {
        gameOverText.enabled = true;
        // This freezes the game
        Time.timeScale = 0;
    }
}

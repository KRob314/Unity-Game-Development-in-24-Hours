using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text gameOverText;
    public Text powerupText;

    int playerScore = 0;
    private float elapsedTime = 0;

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

    public void PowerupEnabled(int secondsActive)
    {
        powerupText.enabled = true;

        StartCoroutine(Countdown5());
    }

    public void Update()
    {
        elapsedTime = elapsedTime + Time.deltaTime;

        return;

        if (elapsedTime > 5)
        {
            elapsedTime = 0;
            Time.timeScale += .3f;

            Debug.Log(Time.timeScale);
        }
    }

    private IEnumerator Countdown5()
    {
        int seconds = 5;
        while (seconds >= 0)
        {
            powerupText.text = $"power up: {seconds}";
            seconds -= 1;


            yield return new WaitForSeconds(1);
            powerupText.text = "";
        }
    }

}

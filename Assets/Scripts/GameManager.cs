using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Text that display "Game over" when the game ends
    public GameObject gameOverText;
    // Text that displays the score
    public GameObject scoreText;
    // Check if the game is over or not
    public bool isOver = false;
    // The player
    public GameObject player;
    // The obstacle spawner
    public GameObject obstacleSpawner;
    // Current score
    public int score = 0;
    // The text of high score
    //public GameObject highScoreText;
    // Current highscore
    public int highScore;

    // Obstacles speed
    public float obstaclesSpeed = 50f;

    // Play again button
    public GameObject playAgainButton;
    // QUit game button
    public GameObject quitGameButton;

    bool updatedText = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData data = SaveAndLoad.Load();
        highScore = data._highScore;

        playAgainButton.SetActive(false);
        quitGameButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Update game over text
        if (isOver && !updatedText)
        {
            updatedText = true;
            gameOverText.GetComponent<Text>().text = "Game Over!" +"\nScore: " + score.ToString() + "\nHigh score: " + highScore.ToString();
        }

        // Turn on the 2 buttons when the game is over
        if(isOver && !playAgainButton.activeSelf)
        {
            playAgainButton.SetActive(true);
            quitGameButton.SetActive(true);
        }

        // Turn off the 2 buttons when the game is not over
        if (!isOver && playAgainButton.activeSelf)
        {
            playAgainButton.SetActive(false);
            quitGameButton.SetActive(false);
        }

        // Reset game by pressing r
        if (Input.GetKeyDown("r") && isOver)
        {
            RestartGame();
        }

        // Update high score if
        if(score > highScore)
        {
            highScore = score;

            PlayerData newRecord = new PlayerData(highScore);
            SaveAndLoad.pData = newRecord;
            SaveAndLoad.Save();
        }

        scoreText.GetComponent<Text>().text = score.ToString();
        //highScoreText.GetComponent<Text>().text = "Highscore: " + highScore.ToString(); 
    }

    public void RestartGame()
    {
        score = 0;
        isOver = false;
        updatedText = false;
        gameOverText.GetComponent<Text>().text = "";
        player.GetComponentInChildren<PlayerController>().resetGame();
        obstacleSpawner.GetComponent<ObstacleSpawner>().resetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

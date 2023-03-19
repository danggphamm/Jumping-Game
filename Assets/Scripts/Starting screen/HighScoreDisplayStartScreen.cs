using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreDisplayStartScreen : MonoBehaviour
{
    public GameObject highScoreText;
    PlayerData data;

    void Start()
    {
        // Load the record when the game start
        data = SaveAndLoad.Load();
        highScoreText.GetComponent<Text>().text = "High score: " + data._highScore.ToString();
    }
}

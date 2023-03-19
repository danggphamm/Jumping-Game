using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Class that contains the player data
[Serializable]
public class PlayerData
{
    // The high score
    public int _highScore;

    // Constructor
    public PlayerData(int highScore)
    {
        _highScore = highScore;
    }

    // Set highScore
    public void SetHighScore(int highScore)
    {
        _highScore = highScore;
    }
}
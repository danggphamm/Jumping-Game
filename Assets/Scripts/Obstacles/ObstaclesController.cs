using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    // Speed of the obstacle
    public float speed = 50f;
    // The game manager object that contains information about the current state of the game
    GameObject gameManager;
    Vector3 startPosition;

    // Update is called once per frame
    void Start()
    {
        startPosition = transform.position;
        gameManager = GameObject.Find("GameManager");
    }
    void Update()
    {
        // If not game over
        if (!gameManager.GetComponent<GameManager>().isOver) 
        {
            // Move the obstacle
            Vector3 newPosition = transform.position + Vector3.left * speed * Time.deltaTime;
            transform.position = newPosition;
        }
    }
    
    public void resetGame()
    {
        transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);
    }
}

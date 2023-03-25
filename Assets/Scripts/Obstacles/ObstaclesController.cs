using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to move obstacles
public class ObstaclesController : MonoBehaviour
{
    // Speed of the obstacle
    float speed;
    // The game manager object that contains information about the current state of the game
    GameObject gameManager;
    Vector3 startPosition;

    // Update is called once per frame
    void Start()
    {
        startPosition = transform.position;
        gameManager = GameObject.Find("GameManager");
        speed = gameManager.GetComponent<GameManager>().obstaclesSpeed;
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

        // Destroy the obstacle if it moves offscreen
        if (transform.position.x < -170)
        {
            Destroy(gameObject);
        }
    }
    
    public void resetGame()
    {
        transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);
    }
}

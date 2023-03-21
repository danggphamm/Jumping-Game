using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodObstaclesCollisionBehaviour : MonoBehaviour
{
    // The game manager object that contains information about the current state of the game
    GameObject gameManager;
    GameObject ObstacleSpawner;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        ObstacleSpawner = GameObject.Find("Obstacle spawner");
    }

    void OnTriggerEnter(Collider other)
    {
        // If collide with the player
        if (other.tag.ToLower() == "player")
        {
            gameManager.GetComponent<GameManager>().score += GetComponent<GoodObstaclesStat>().point;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy the obstacle if it moves offscreen
        if (transform.position.x < -170)
        {
            ObstacleSpawner.GetComponent<ObstacleSpawner>().obstacles.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 100f;
    Vector3 startPosition;

    // The game manager object that contains information about the current state of the game
    GameObject gameManager;

    void Start()
    {
        startPosition = transform.position;
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        // Check if space is pressed and game is not over
        if (Input.GetKeyDown("space") && !gameManager.GetComponent<GameManager>().isOver)
        {
            // Reset the velocity
            GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            // Add foce to jump
            GetComponent<Rigidbody>().AddForce(Vector3.up);
        }

        // If game is over
        if(gameManager.GetComponent<GameManager>().isOver)
        {
            // Reset the velocity
            GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // If collide with an obstacle
        if(collision.collider.tag.ToLower() == "obstacle")
        {
            gameManager.GetComponent<GameManager>().isOver = true;
        }

        // If collide with the scoring obstacle
        if (collision.collider.tag.ToLower() == "score")
        {
            gameManager.GetComponent<GameManager>().score ++;
        }
    }

    public void resetGame()
    {
        // Reset the velocity
        GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        // Reset the position
        transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);
    }
}

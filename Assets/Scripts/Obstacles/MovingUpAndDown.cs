using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingUpAndDown : MonoBehaviour
{
    // Speed of the obstacle
    public float speed;

    int direction = 0;
    float topLimit;
    float bottomLimit;
    public float movingRange = 10f;

    // The game manager object that contains information about the current state of the game
    GameObject gameManager;
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        topLimit = transform.position.y + movingRange;
        bottomLimit = transform.position.y - movingRange;
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        // If not game over
        if (!gameManager.GetComponent<GameManager>().isOver)
        {
            // If direction is up
            if(direction == 0)
            {
                // Move the obstacle up
                Vector3 newPosition = transform.position + Vector3.up * speed * Time.deltaTime;
                transform.position = newPosition;
            }
            else
            {
                // Else move the obstacle down
                Vector3 newPosition = transform.position + Vector3.down * speed * Time.deltaTime;
                transform.position = newPosition;
            }

            // Change direction
            if(transform.position.y < bottomLimit)
            {
                direction = 0;
            }
            else if (transform.position.y > topLimit)
            {
                direction = 1;
            }
        }
    }
}

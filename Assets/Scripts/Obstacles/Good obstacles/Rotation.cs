using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // The game manager object that contains information about the current state of the game
    GameObject gameManager;
    // Speed of the obstacle
    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        // Move the obstacle
        transform.Rotate(0.0f, speed, 0.0f, Space.Self);
    }
}

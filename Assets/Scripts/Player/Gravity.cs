using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public Vector3 customGravity = new Vector3(0f, 0.02f, 0f);

    // The game manager object that contains information about the current state of the game
    GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        // If not game over
        if (!gameManager.GetComponent<GameManager>().isOver)
        {
            //  Adding custom gravity
            GetComponent<Rigidbody>().velocity += customGravity * Time.deltaTime;
        }
    }
}

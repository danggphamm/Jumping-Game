using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To spawn obstacles
public class ObstacleSpawner : MonoBehaviour
{
    // The rate of spawning
    public float spawningRate = 3f;

    // The random vertical position adjustments of the obstancles
    public float verticalAdjustmentRate = 20f;

    // The obstacle
    public GameObject obstacle;

    List<GameObject> obstacles = new List<GameObject>();

    // The game manager object that contains information about the current state of the game
    GameObject gameManager;

    float lastTime;
    float currentTime;
    void Start()
    {
        GameObject instance = Instantiate(obstacle, transform.position, transform.rotation);
        obstacles.Add(instance);
        lastTime = Time.time;
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;

        if ((currentTime - lastTime)> spawningRate && !gameManager.GetComponent<GameManager>().isOver)
        {
            lastTime = currentTime;
            float newY = transform.position.y - verticalAdjustmentRate / 2 + Random.Range(0, verticalAdjustmentRate + 1);
            Vector3 newPosition = new Vector3(transform.position.x, newY, transform.position.z);
            GameObject instance = Instantiate(obstacle, newPosition, transform.rotation);
            obstacles.Add(instance);
        }
    }

    // reset the game
    public void resetGame()
    {
        foreach (GameObject obstacle in obstacles)
        {
            Destroy(obstacle);
        }

        lastTime = Time.time;
        GameObject instance = Instantiate(obstacle, transform.position, transform.rotation);
        obstacles.Add(instance);
    }
}

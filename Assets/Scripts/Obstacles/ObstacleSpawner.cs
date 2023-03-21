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

    // The random vertical position adjustments of the reward obstacle type 1
    public float verticalAdjustmentRateRewardType1 = 15f;

    // The random vertical position adjustments of the reward obstacle type 2
    public float verticalAdjustmentRateRewardType2 = 15f;

    // The obstacle
    public GameObject obstacle;

    // The reward obstacles type 1
    public GameObject goodObstacleType1;

    // The reward obstacles type 2
    public GameObject goodObstacleType2;

    // The chance of spawning reward - type 1 - in percent
    public float rewardType1SpawningRatio = 15f;
    bool spawnedType1 = false;

    // The chance of spawning reward - type 2 - in percent
    public float rewardType2SpawningRatio = 25f;
    bool spawnedType2 = false;


    // the random y position of the new obstacle
    float newY = 0f;

    public List<GameObject> obstacles = new List<GameObject>();

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

        // Spawn obstacle every spawningrate
        if ((currentTime - lastTime)> spawningRate && !gameManager.GetComponent<GameManager>().isOver)
        {
            // Update last spwaning time
            lastTime = currentTime;

            spawnedType1 = false;
            spawnedType2 = false;
            // Calculate the random position of the new obstacle
            newY = transform.position.y - verticalAdjustmentRate / 2 + Random.Range(0, verticalAdjustmentRate + 1);
            Vector3 newPosition = new Vector3(transform.position.x, newY, transform.position.z);
            GameObject instance = Instantiate(obstacle, newPosition, transform.rotation);
            obstacles.Add(instance);
        }

        // Randomly spawn rewards type 1
        if ((currentTime - lastTime) - spawningRate / 2 < 0.1f && !gameManager.GetComponent<GameManager>().isOver && !spawnedType1)
        {
            // Spawn reward at most one per cycle
            spawnedType1 = true;

            // The rate of reward type 1
            if (Random.Range(0, 100) < rewardType1SpawningRatio && newY != 0f)
            {
                Vector3 newPosition = new Vector3(transform.position.x, newY - verticalAdjustmentRateRewardType1 / 2 + Random.Range(0, verticalAdjustmentRateRewardType1 + 1), transform.position.z);
                GameObject instance = Instantiate(goodObstacleType1, newPosition, transform.rotation);
                obstacles.Add(instance);
            }
        }

        // Randomly spawn rewards type 2
        else if ((currentTime - lastTime) - spawningRate / 2 < 0.1f && !gameManager.GetComponent<GameManager>().isOver && !spawnedType2)
        {
            // Spawn reward at most one per cycle
            spawnedType2 = true;

            // The rate of reward type 2
            if (Random.Range(0, 100) < rewardType2SpawningRatio )
            {
                Vector3 newPosition = new Vector3(transform.position.x, newY, transform.position.z);
                GameObject instance = Instantiate(goodObstacleType2, newPosition, transform.rotation);
                obstacles.Add(instance);
            }
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

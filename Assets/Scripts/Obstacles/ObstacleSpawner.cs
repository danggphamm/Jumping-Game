using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To spawn obstacles
public class ObstacleSpawner : MonoBehaviour
{
    // The rate of spawning
    public float spawningRate = 3f;

    // The rate of spawning
    public float spawningRateType2 = 20f;

    public float type2XAdjustmentRate;
    public float timeSpawningForwardType2;

    // The random vertical position adjustments of the obstancles
    public float verticalAdjustmentRate = 20f;

    // The random vertical position adjustments of the reward obstacle type 1
    public float verticalAdjustmentRateRewardType1 = 15f;

    // The random vertical position adjustments of the reward obstacle type 2
    public float verticalAdjustmentRateRewardType2 = 15f;

    // The obstacle
    public GameObject obstacle;

    public float obstacleType1SpawningRate;

    // The obstacle
    public GameObject obstacleType2;

    // The reward obstacles type 1
    public GameObject goodObstacleType1;

    // The reward obstacles type 2
    public GameObject goodObstacleType2;

    // The chance of spawning reward - type 1 - in percent
    public float rewardType1SpawningRatio = 15f;

    // The chance of spawning reward - type 2 - in percent
    public float rewardType2SpawningRatio = 25f;

    bool spawnedObstacle = false;
    bool decidedTurn = true;
    int turn = 0;


    // the random y position of the new obstacle
    float newY = 0f;

    bool spawned = false;
    bool spawnedType2 = false;

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

        if (!decidedTurn)
        {
            if(Random.Range(0, 100) < obstacleType1SpawningRate)
            {
                turn = 0;
            }
            else
            {
                turn = 1;
            }
            decidedTurn = true;
        }

        if (turn == 0)
        {
            // Spawn obstacle every spawningrate
            if ((currentTime - lastTime) > spawningRate && !gameManager.GetComponent<GameManager>().isOver)
            {
                // Update last spwaning time
                lastTime = currentTime;

                spawned = false;
                // Calculate the random position of the new obstacle
                newY = transform.position.y - verticalAdjustmentRate / 2 + Random.Range(0, verticalAdjustmentRate + 1);
                Vector3 newPosition = new Vector3(transform.position.x, newY, transform.position.z);
                GameObject instance = Instantiate(obstacle, newPosition, transform.rotation);
                obstacles.Add(instance);
                decidedTurn = false;
            }

            // Randomly spawn rewards type 1
            if ((currentTime - lastTime) - spawningRate / 2 < 0.1f && !gameManager.GetComponent<GameManager>().isOver && !spawned)
            {
                // Spawn reward at most one per cycle
                spawned = true;

                // The rate of reward type 1
                if (Random.Range(0, 100) < rewardType1SpawningRatio && newY != 0f)
                {
                    Vector3 newPosition = new Vector3(transform.position.x, newY - verticalAdjustmentRateRewardType1 / 2 + Random.Range(0, verticalAdjustmentRateRewardType1 + 1), transform.position.z);
                    GameObject instance = Instantiate(goodObstacleType1, newPosition, transform.rotation);
                    obstacles.Add(instance);
                }
            }

            // Randomly spawn rewards type 2
            else if ((currentTime - lastTime) - spawningRate / 2 < 0.1f && !gameManager.GetComponent<GameManager>().isOver && !spawned)
            {
                // Spawn reward at most one per cycle
                spawned = true;

                // The rate of reward type 2
                if (Random.Range(0, 100) < rewardType2SpawningRatio)
                {
                    Vector3 newPosition = new Vector3(transform.position.x, newY, transform.position.z);
                    GameObject instance = Instantiate(goodObstacleType2, newPosition, transform.rotation);
                    obstacles.Add(instance);
                }
            }
        }
        else
        {
            // Spawn obstacle every spawningrate
            if ((currentTime - lastTime) > spawningRateType2 / 2 - 3f && !gameManager.GetComponent<GameManager>().isOver && !spawnedType2)
            {
                // Calculate the random position of the new obstacle
                spawnedType2 = true;
                Vector3 newPosition = new Vector3(transform.position.x + type2XAdjustmentRate, transform.position.y + 20, transform.position.z);
                GameObject instance = Instantiate(obstacleType2, newPosition, transform.rotation);
                instance.transform.Rotate(0.0f, 0.0f, Random.Range(0, 360), Space.Self);
                obstacles.Add(instance);
            }

            if ((currentTime - lastTime) > spawningRateType2/2 && !gameManager.GetComponent<GameManager>().isOver)
            {
                // Update last spwaning time
                lastTime = currentTime;
                decidedTurn = false;
                spawnedType2 = false;
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

        spawnedObstacle = false;
        spawnedType2 = false;
        spawned = false;
        decidedTurn = true;
        lastTime = Time.time;
        GameObject instance = Instantiate(obstacle, transform.position, transform.rotation);
        obstacles.Add(instance);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodObstaclesCollisionBehaviour : MonoBehaviour
{
    // The game manager object that contains information about the current state of the game
    GameObject gameManager;
    GameObject ObstacleSpawner;
    public GameObject scorePopUpPrefab;
    GameObject player;
    GameObject canvas;
    GameObject mainCamera;
    GameObject popUpPos;
    public float adjustmentX = 20f;
    public float adjustmentY = -50f;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        ObstacleSpawner = GameObject.Find("Obstacle spawner");
        canvas = GameObject.Find("Canvas");
        player = GameObject.Find("PlayerGraphic");
        popUpPos = GameObject.Find("PopUpPos");
        mainCamera = GameObject.Find("Main Camera");
    }

    void OnTriggerEnter(Collider other)
    {
        // If collide with the player
        if (other.tag.ToLower() == "player")
        {
            RectTransform CanvasRect = canvas.GetComponent<RectTransform>();
            Vector3 screenPos = mainCamera.GetComponent<Camera>().WorldToScreenPoint(transform.position);
            Vector3 uiPos = new Vector3(screenPos.x, Screen.height - screenPos.y + adjustmentY, screenPos.z);

            gameManager.GetComponent<GameManager>().score += GetComponent<GoodObstaclesStat>().point;
            Vector3 newPos = new Vector3(uiPos.x, uiPos.y, uiPos.z);
            GameObject scorePopUp = Instantiate(scorePopUpPrefab, newPos, transform.rotation, canvas.transform);
            scorePopUp.transform.rotation = Quaternion.identity;
            scorePopUp.GetComponent<ScorePopUp>().score = GetComponent<GoodObstaclesStat>().point;
            scorePopUp.GetComponent<ScorePopUp>().lastTime = Time.time;
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

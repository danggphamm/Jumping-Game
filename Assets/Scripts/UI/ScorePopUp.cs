using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePopUp : MonoBehaviour
{
    // Duration the pop up last
    public float duration = 2.5f;

    public float popUpSpeed = 0.2f;

    public int score;
    float speed;
    // The game manager object that contains information about the current state of the game
    GameObject gameManager;

    public float lastTime;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        speed = gameManager.GetComponent<GameManager>().obstaclesSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "+" + score.ToString();

        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + popUpSpeed, transform.position.z);
        newPosition = newPosition + Vector3.left * speed * Time.deltaTime;
        transform.position = newPosition;

        if(Time.time - lastTime > duration)
        {
            Destroy(gameObject);
        }
    }
}

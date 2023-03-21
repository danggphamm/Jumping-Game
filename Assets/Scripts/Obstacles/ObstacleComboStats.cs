using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleComboStats : MonoBehaviour
{
    GameObject topObstacle;
    GameObject bottomObstacle;
    public float distanceBetweenTopAndBottom = 350f;
    // Start is called before the first frame update
    void Start()
    {
        // 2 children objects
        topObstacle = transform.Find("Obstacle top").gameObject;
        bottomObstacle = transform.Find("Obstacle bottom").gameObject;

        topObstacle.transform.position = new Vector3(bottomObstacle.transform.position.x, bottomObstacle.transform.position.y + distanceBetweenTopAndBottom, bottomObstacle.transform.position.z);
    }
}

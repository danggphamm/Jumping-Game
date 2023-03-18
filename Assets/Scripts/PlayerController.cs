using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 100f;
    // Update is called once per frame
    void Update()
    {
        // Check if space is pressed
        if (Input.GetKeyDown("space"))
        {
            // Reset the velocity
            GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            // Add foce to jump
            GetComponent<Rigidbody>().AddForce(Vector3.up*speed);
        }
    }
}

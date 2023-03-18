using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    Vector3 startVelocity;
    public Vector3 customGravity = new Vector3(0f, 0.02f, 0f);

    void Start()
    {
        startVelocity = GetComponent<Rigidbody>().velocity;
    }

    // Update is called once per frame
    void Update()
    {
        //  Adding custom gravity
        GetComponent<Rigidbody>().velocity += customGravity * Time.fixedDeltaTime;
    }
}

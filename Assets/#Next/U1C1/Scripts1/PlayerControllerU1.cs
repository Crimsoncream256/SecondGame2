using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerU1 : MonoBehaviour
{
    public float speed = 20.0f;
    public float turnSpeed = 45f;
    void Start()
    {
        
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * turnSpeed);
    }
}

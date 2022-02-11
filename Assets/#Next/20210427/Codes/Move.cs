using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 8f;
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            var velox = speed * Input.GetAxisRaw("Horizontal") / 2;
            GetComponent<Rigidbody>().velocity = new Vector3(velox, 0f, 0f);
        }
        else
        {
            var velox = speed * Input.GetAxisRaw("Horizontal");
            GetComponent<Rigidbody>().velocity = new Vector3(velox, 0f, 0f);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardX2 : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("0");
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}

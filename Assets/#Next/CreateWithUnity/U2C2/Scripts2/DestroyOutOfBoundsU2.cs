using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsU2 : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;
    void Update()
    {
        if (transform.position.z > topBound || transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}

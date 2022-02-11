using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broken1 : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "LeaderBall")
        {
            GetComponent<Renderer>().material.color = Color.red;
            Destroy (gameObject, 2.5f);
        }
    }
}

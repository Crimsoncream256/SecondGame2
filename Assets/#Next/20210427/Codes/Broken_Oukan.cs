using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broken_Oukan : MonoBehaviour
{


    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {

            Destroy(gameObject);
        }
    }
}

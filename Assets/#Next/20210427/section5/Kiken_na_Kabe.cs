using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiken_na_Kabe : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball"){
            Destroy(other.gameObject, 0.1f);
        }
        if (other.gameObject.tag == "BBall")
        {
            Destroy(other.gameObject, 0.1f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class KillEnemy : MonoBehaviour
{
    public ParticleSystem explosion;
    void Start()
    {
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Kill")
        {
            explosion.transform.position = other.transform.position;
            other.gameObject.SetActive(false);
            explosion.Play();
        }
    }
}


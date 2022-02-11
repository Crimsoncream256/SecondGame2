using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{

    public GameManager gameManager;

    private new AudioSource audio;
    public AudioClip StoneBreaking;
    public float bounce = 10.0f;

    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
    }


    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ball")
        {
            Vector3 norm = other.contacts[0].normal;
            Vector3 vel = new Vector3(-norm.x, 0f, -norm.z);
            other.rigidbody.AddForce(vel.normalized * bounce, ForceMode.VelocityChange);
            audio.PlayOneShot(StoneBreaking);
        }
        if (other.gameObject.tag == "BBall")
        {
            Vector3 norm = other.contacts[0].normal;
            Vector3 vel = new Vector3(-norm.x, 0f, -norm.z);
            other.rigidbody.AddForce(vel.normalized * bounce/2, ForceMode.VelocityChange);
            audio.PlayOneShot(StoneBreaking);
        }
    }

}

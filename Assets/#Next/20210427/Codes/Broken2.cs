using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broken2 : MonoBehaviour
{
    private AudioSource audio;

    public AudioClip StoneBreaking;
    public AudioClip StoneCrack;

    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ball")
        {
            GetComponent<Renderer>().material.color = Color.red;
            //audio.PlayOneShot(StoneCrack);
            GetComponent<Transform>().localScale =
new Vector3(2f, 5.0f, 10f);
            audio.PlayOneShot(StoneBreaking);
            Destroy (gameObject, 0.5f);
        }
        if (other.gameObject.tag == "BBall")
        {
            GetComponent<Renderer>().material.color = Color.red;
            //audio.PlayOneShot(StoneCrack);
            GetComponent<Transform>().localScale =
new Vector3(2f, 5.0f, 10f);
            audio.PlayOneShot(StoneBreaking);
            Destroy(gameObject, 0.5f);
        }
    }
}

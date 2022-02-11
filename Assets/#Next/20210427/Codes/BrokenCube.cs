using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenCube : MonoBehaviour
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
new Vector3(0.5f, 0.5f, 0.5f);
            audio.PlayOneShot(StoneBreaking);
            Destroy (gameObject, 0.5f);
        }
    }
}

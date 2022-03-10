using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Broken2 : MonoBehaviour
{
    public GameManager gm;

    private AudioSource audio;

    public AudioClip StoneBreaking;
    public AudioClip StoneCrack;


    public Slider slider;

    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
        slider.onValueChanged.AddListener(value => this.audio.volume = value);

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

            gm.PlusCoins(1);
            /*
            gm.PlusCoinsInGame(1);
            gm.PlusCoinsAll();
            */
            Destroy (gameObject, 0.5f);
        }
        if (other.gameObject.tag == "BBall")
        {
            GetComponent<Renderer>().material.color = Color.red;
            //audio.PlayOneShot(StoneCrack);
            GetComponent<Transform>().localScale =
new Vector3(2f, 5.0f, 10f);
            audio.PlayOneShot(StoneBreaking);

            gm.PlusCoins(1);
            /*
            gm.PlusCoinsInGame(1);
            gm.PlusCoinsAll();
            */
            Destroy(gameObject, 0.5f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chibi_Broken : MonoBehaviour
{
    private new AudioSource audio;

    public AudioClip StoneBreaking;
    public AudioClip StoneCrack;
    public int scorepointB = 20;
    public int scorepointF = 10;
    public int Fallen = 1;
    public int Broken = 1;

    public int fAlLen;
    public int bRoKen;

    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ball")
        {
            GetComponent<Renderer>().material.color = Color.red;
            GetComponent<Transform>().localScale =
new Vector3(0.1f, 0.1f, 0.1f);
            GameObject gm = GameObject.Find("GOD");
            gm.GetComponent<GameManager>().AddScore(scorepointB);
             GameObject gmB = GameObject.Find("GOD");
            gmB.GetComponent<GameManager>().AddBroken(Broken);


            audio.PlayOneShot(StoneBreaking);
            Destroy (gameObject, 0.5f);
        }
        if (other.gameObject.tag == "BBall")
        {
            GetComponent<Renderer>().material.color = Color.red;
            GetComponent<Transform>().localScale =
new Vector3(0.1f, 0.1f, 0.1f);
            GameObject gm = GameObject.Find("GOD");
            gm.GetComponent<GameManager>().AddScore(scorepointB);
            GameObject gmB = GameObject.Find("GOD");
            gmB.GetComponent<GameManager>().AddBroken(Broken);


            audio.PlayOneShot(StoneBreaking);
            Destroy(gameObject, 0.5f);
        }
    }

    void Update()
    {
        if (gameObject.transform.position.y <= -3)
        {
                       Debug.Log(this.gameObject.name);

            GameObject gm = GameObject.Find("GOD");
            gm.GetComponent<GameManager>().AddScore(scorepointF);

            GameObject gmF = GameObject.Find("GOD");
            gmF.GetComponent<GameManager>().AddFallen(Fallen);
            

            Destroy(this.gameObject);
        }
    }
}

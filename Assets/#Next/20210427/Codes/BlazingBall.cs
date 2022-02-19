using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlazingBall : MonoBehaviour
{
    public new AudioSource audio;
    public AudioClip Gusha;
    public GameManager0427 gameManager;
    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("あたった");
             audio.PlayOneShot(Gusha);
            //ここでGameManagerのlifeを1減らす
            GameObject gm = GameObject.Find("GOD");
            gm.GetComponent<GameManager0427>().BallDelete();
            //--gameManager.life;
            Debug.Log("あつい！");//当てたらちゃんと出てきました
            GameObject gm2 = GameObject.Find("GOD");
            gm2.GetComponent<GameManager0427>().check("Ball");
            Destroy(gameObject);
        }
    }
}


//これは　　テストです
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingSphere : MonoBehaviour
{
    private new AudioSource audio;
    public AudioClip Explode;

    public GameManager gameManager;

    public int scorepointB = 200;
    public int Broken = 10;

    public int scorepointBc = 20;
    public int Brokenc = 1;

    public int bRoKen;

    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
        
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Ball")
        {
            GetComponent<Renderer>().material.color = Color.red;
            GameObject gm = GameObject.Find("GOD");
            gm.GetComponent<GameManager>().AddScore(scorepointB);
            GameObject gmB = GameObject.Find("GOD");
            gmB.GetComponent<GameManager>().AddBroken(Broken);

            audio.PlayOneShot(Explode);
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("KABE");

            // GameObject型の変数cubeに、cubesの中身を順番に取り出す。
            // foreachは配列の要素の数だけループします。
            foreach (GameObject cube in cubes)
            {
                // 消す！
                Destroy(cube);

                GameObject gmE = GameObject.Find("GOD");
                gmE.GetComponent<GameManager>().AddScore(scorepointBc);
                GameObject gmBE = GameObject.Find("GOD");
                gmBE.GetComponent<GameManager>().AddBroken(Brokenc);

                Debug.Log("どっかーん！");
                Destroy(gameObject, 2f);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

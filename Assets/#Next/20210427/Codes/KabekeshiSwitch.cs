using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KabekeshiSwitch : MonoBehaviour
{
    private AudioSource audiO;

    public AudioClip Kachi;

    public int scorepointB = 200;
    public int Broken = 1;

    public int bRoKen;

    private void Start()
    {
        this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);
        audiO = gameObject.AddComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audiO.PlayOneShot(Kachi);
            this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("KAGO");

            // GameObject型の変数cubeに、cubesの中身を順番に取り出す。
            // foreachは配列の要素の数だけループします。
            foreach (GameObject cube in cubes)
            {
                // 消す！
                Destroy(cube);
                Debug.Log("どっかーん！");
                Destroy(gameObject, 2f);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1, 1);
        }
    }
}

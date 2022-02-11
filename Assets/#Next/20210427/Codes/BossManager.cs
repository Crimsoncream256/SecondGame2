using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{
    public int BossLife;  //この回数分プレイヤーの弾を当てたら動きが止まってゲームクリア   これGameManagerに入れた方がよくないか
    //public string BossNokori;//文字列  これGameManagerに入れた方がよくないか

    public GameManager gameManager; //なんか変数とか使いそうだから呼んどいた
    public float speed = 4f; //動かすため
    public GameObject BlazingBallPrefab;//炎玉のプレハブ

    private Vector3 targetpos;

    public GameObject Bakufuu;

    public new AudioSource audio;
    public AudioClip Damage;
    public AudioClip Killed;

    public Text BossNokori;


    public int scorepointB = 2000;
    public int Broken = 100;

    public int scorepointBc = 20;
    public int Brokenc = 1;

    public int bRoKen;

    public int DefaultTamakazu;
    GameObject[] tagObjects;

    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();

        if (SceneManager.GetActiveScene().name == "Seclet1")
        {
            BossLife = 100;
            DefaultTamakazu = 3;
        }
        else if (SceneManager.GetActiveScene().name == "Boss1")
        {
            BossLife = 10;
            DefaultTamakazu = 0;
        }
            
        targetpos = transform.position;
    }

    private void SetNokoriText(int BossLife)
    {
        BossNokori.text = "オレサマのこり:" + BossLife.ToString();
    }

    void BAKUHATSU()
    {
        //エフェクトを生成する
        GameObject effect = Instantiate(Bakufuu) as GameObject;
        //エフェクトが発生する場所を決定する(敵オブジェクトの場所)
        effect.transform.position = gameObject.transform.position;
    }

    void check(string tagname)
    {
        tagObjects = GameObject.FindGameObjectsWithTag(tagname);
        Debug.Log(tagObjects.Length);
        if (tagObjects.Length <= DefaultTamakazu)
        {
            float x = Random.Range(1.0f, -1.0f);
            float y = Random.Range(5.0f, 3.0f);
            float z = Random.Range(-3.0f, 3.0f);
            GameObject newBall = Instantiate(BlazingBallPrefab, new Vector3(x, y, z), Quaternion.identity);
            newBall.name = BlazingBallPrefab.name;
        }
    }


    void OnCollisionEnter(Collision AAAAA)
    {
        if (AAAAA.gameObject.tag == "Ball")
        {
            --BossLife;
            SetNokoriText(BossLife);
            Debug.Log("あたった！");
            GameObject gm = GameObject.Find("GOD");
            gm.GetComponent<GameManager>().AddScore(scorepointBc);
            GameObject gmO = GameObject.Find("GOD");
            gmO.GetComponent<GameManager>().AddBroken(Brokenc);
            audio.PlayOneShot(Damage);
            if (BossLife <= 0)
            {
                audio.PlayOneShot(Killed);
                BAKUHATSU();
                Debug.Log("やられたー！");

                //ここでCREAREDSwitchを1にする
                //のと同じような動作をする(?!)

                GameObject gmE = GameObject.Find("GOD");
                gmE.GetComponent<GameManager>().AddScore(scorepointB);
                GameObject gmBE = GameObject.Find("GOD");
                gmBE.GetComponent<GameManager>().AddBroken(Broken);

                GameObject[] cubes = GameObject.FindGameObjectsWithTag("KABE");
                foreach (GameObject cube in cubes)
                {
                    Destroy(cube);
                    GameObject gmB = GameObject.Find("GOD");
                    gmB.GetComponent<GameManager>().AddScore(scorepointBc);
                    GameObject gmBB = GameObject.Find("GOD");
                    gmBB.GetComponent<GameManager>().AddBroken(Brokenc);
                    Debug.Log("どっかーん！");
                }
                Destroy(gameObject);
            }
        }
    }


    void Update()
    {
        //GameObject newBall = Instantiate(BlazingBallPrefab);
        //newBall.name = BlazingBallPrefab.name;

        //これが動かすやつ
        transform.position = new Vector3(Mathf.Sin(Time.time) * 4.0f + targetpos.x, targetpos.y, targetpos.z);
        check("BBall");
    }
}

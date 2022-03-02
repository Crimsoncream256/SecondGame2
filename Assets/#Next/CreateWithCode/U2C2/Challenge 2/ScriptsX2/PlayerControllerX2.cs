using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerX2 : MonoBehaviour
{
    public GameObject dogPrefab;

    private float leftTime;
    public Text textTimer;

    public int Tamakazu;
    public int DefaultTamakazu = 3;
    GameObject[] tagObjects;
    public bool isGameActive;

    public void check(string tagname)
    {
        tagObjects = GameObject.FindGameObjectsWithTag(tagname);
        Debug.Log(tagObjects.Length); //tagObjects.Lengthはオブジェクトの数
        //if (tagObjects.Length < DefaultTamakazu)
        {
            Debug.Log(tagname + "タグつきobjがTamakazuより少ない");
            //この逆は　タグ付きobjがTamakazuより多い　　つまりtagObjects.Length > DefaultTamakazu
        }
    }

    public void checkDoggy(string tagname)
    {
        tagObjects = GameObject.FindGameObjectsWithTag(tagname);
        //Debug.Log(tagObjects.Length); //tagObjects.Lengthはオブジェクトの数

        if (tagObjects.Length == 0)
        {
            Debug.Log(tagname + "タグがついたオブジェクトはありません");
        }
        else if (tagObjects.Length < DefaultTamakazu)
        {
            Debug.Log(tagname + "タグつきobjがDefaultTamakazuより少ない");
        }
        else if (tagObjects.Length > DefaultTamakazu)
        {
            Debug.Log(tagname + "タグつきobjがDefaultTamakazuより多い");
        }
        else
        {
            if (tagObjects.Length > DefaultTamakazu + 1)
            {
                Debug.Log("One More One");
            }
            Debug.Log("ﾚｲｶﾞｲ");
        }
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        DefaultTamakazu = difficulty;
        Tamakazu = DefaultTamakazu;
        Debug.Log("ﾅﾝｲﾄﾞﾊ"+difficulty);
        leftTime = 100f;
    }


    void Start()
    {
        StartGame(5);
    }

    void Update()
    {
        tagObjects = GameObject.FindGameObjectsWithTag("Dog");
        //Debug.Log(tagObjects.Length);

        leftTime -= Time.deltaTime;
        textTimer.text = "Time:" + (leftTime > 0f ? leftTime.ToString("0.00") : "0.00");

        // On spacebar press, send dog

        //Dogタグ付きのわんこは、画面内にいる数がDefaultTamakazuより少なければ召喚できる　　if(tagObjects.Length < DefaultTamakazu){わんこ召喚}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            checkDoggy("Dog");

            tagObjects = GameObject.FindGameObjectsWithTag("Dog");
            if (tagObjects.Length + 1 <= DefaultTamakazu)//わんこ <= 5つ
            {
                Debug.Log("true");
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            }
            else if (tagObjects.Length > DefaultTamakazu)
            {
                Debug.Log("わんこが多すぎます");
            }
        }
    }
}

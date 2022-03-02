using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManagerX4 : MonoBehaviour
{
    public SpawnManagerX4 sp4;
    public PlayerControllerX4 pcx4;
    public GameManager gm;

    public Text textscore;
    public int score;
    public float defaultTime;
    private float time;
    public Text textTime;

    void Start()
    {
        check();
        time = defaultTime;
    }

    public void check()
    {
        //score += 10;
        //Debug.Log(score);
        textscore.text = "score: " + score;
        
    }

    void Update()
    {
        time -= Time.deltaTime;
        textTime.text = "Time: " + time;
    }
}

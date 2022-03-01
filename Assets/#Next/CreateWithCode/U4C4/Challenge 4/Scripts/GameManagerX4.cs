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

    void Start()
    {
        
    }

    public void check()
    {
        //score += 10;
        //Debug.Log(score);
        textscore.text = "score: " + score;
    }

    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonU5 : MonoBehaviour
{
    private Button button;
    private GameManagerU5 gameManager;
    public int difficulty;

    private float leftTime;
    private Text textTimer;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManagerU5>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }



    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");
        gameManager.StartGame(difficulty);
    }
    void Update()
    {
        
    }
}

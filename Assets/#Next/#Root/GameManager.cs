﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
[System.Serializable]

public class GameManager : MonoBehaviour
{
    [SerializeField] InputField inputArea;
    [SerializeField] Text counterText;
    [SerializeField] bool SecletOpen;
    [SerializeField] static int kidouCount;

    [SerializeField] private GameObject pauseUI;
    [SerializeField] private Text coinsText;

    public List<GameObject> series3List;
    public Text series3avaterText;
    public Text series3VariationText;

    public Text scoreU1Text;
    public Text highscoreU1Text;


    public int inGameMode;


    [System.Serializable]
    public class PlayerDataG
    {//ここに置かれているデータが保存されます
        public int clickCount;
        public string playerName;
        public bool SecletOpened;

        public int coins;

        public int series3AvaterNum;
        public int series3variation;
        public int FarmorTown;

        public int hsU1;
        public int hsU2;
        public int hsU3;
        public int hsU4;
        public int hsU5;

        public int hsX1;
        public int hsX2;
        public int hsX3;

        public int hsX4_0;
        public int hsX4_1;

        public int hsX5;

        public static int startCount; 
    }

    PlayerDataG myData = new PlayerDataG();

    //Group系

    public GameObject lessonGroup;
        public GameObject createWithUnityGroup;
        public GameObject otherGroup;

    //Group系　ココマデ

    //各ゲームハイスコア系

    //各ゲームハイスコア系　ココマデ




    //全体系

    public void debuglogsiro()
    {  Debug.Log("?????????????"); }

    public void OnClickEvent()
    {
        myData.coins++;
        Debug.Log(myData.coins);
        counterText.text = myData.coins.ToString();
    }

    public void isSecletOpened()
    { SecletOpen = true; }

    IEnumerator Timer(int defaultTime)
    {
        int time = defaultTime;
        yield return new WaitForSeconds(defaultTime);

        while (defaultTime >= time)
        {

        }
    }



    public void SavePlayerData()
    {
        StreamWriter writer;
        var playerName = inputArea.text;
        myData.playerName = playerName;

        string jsonstr = JsonUtility.ToJson(myData);

        writer = new StreamWriter(Application.dataPath + "/save" + playerName + ".json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }

    public void LoadPlayerData()
    {
        string datastr = "";
        var playerName = inputArea.text;
        StreamReader reader;

        reader = new StreamReader(Application.dataPath + "/save" + playerName + ".json");
        datastr = reader.ReadToEnd();
        reader.Close();

        myData = JsonUtility.FromJson<PlayerDataG>(datastr); // ロードしたデータで上書き
        Debug.Log(myData.playerName + "のデータをロードしました");
        counterText.text = myData.clickCount.ToString();
        coinsText.text = "coins: " + myData.coins.ToString();
    }




    public void PauseFaction()
    {
        if (Mathf.Approximately(Time.timeScale, 1f))
        {
            Time.timeScale = 0f;
            pauseUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pauseUI.SetActive(false);
        }
    }

    //全体系　ココマデ

    //LoadScene系

        public void Retry()
        { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
    
        public void isRPressed()
        {
            if (Input.GetKeyDown(KeyCode.R))
            { Retry(); }
        }

    //CreateWithCode系

            public void LoadPrototypes(int num) { SceneManager.LoadScene("Prototype " + num); }

            public void ChangeAvaterNumU3(int num)
            {
                myData.series3AvaterNum = num;
                series3avaterText.text = "使用アバター番号: " + myData.series3AvaterNum;
            }

            public void ChangeAvaterVariationU3(int num)
            {
                myData.series3variation = num;
                series3VariationText.text = "バリエーション: " + myData.series3variation;
            }

            public void ChangeAvaterFBXU3()
            {
                
            }

            public void LoadPrototype1() { SceneManager.LoadScene("Prototype 1"); }

            public void LoadPrototype2() { SceneManager.LoadScene("Prototype 2"); }

            public void LoadPrototype3() { SceneManager.LoadScene("Prototype 3"); }

            public void LoadPrototype4() { SceneManager.LoadScene("Prototype 4"); }

            public void LoadPrototype5() { SceneManager.LoadScene("Prototype 5"); }

            public void LoadChallenge1() { SceneManager.LoadScene("Challenge 1"); }

            public void LoadChallenge2()  { SceneManager.LoadScene("Challenge 2"); }

            public void LoadChallenge3()  { SceneManager.LoadScene("Challenge 3"); }

            public void LoadChallenge4() { SceneManager.LoadScene("Challenge 4"); }

            public void LoadChallenge5() { SceneManager.LoadScene("Challenge 5"); }

            public void LoadTitle1() { SceneManager.LoadScene("Title1"); }

            public void LoadTitle2() { SceneManager.LoadScene("Title2"); }

            public void LoadTitle3() { SceneManager.LoadScene("Title3"); }

            public void LoadTitle4() { SceneManager.LoadScene("Title4"); }

            public void LoadTitle5() { SceneManager.LoadScene("Title5"); }

        //CreateWithCode系 ココマデ

        //授業成果系

            public void LoadSection5_2() { SceneManager.LoadScene("Section5_2"); }

            public void LoadSection5_3Continue() { SceneManager.LoadScene("Section5_3Continue"); }

            public void LoadSection5_4Settings() { SceneManager.LoadScene("Section5_3Settings"); }

            public void LoadSection5_5Credits() { SceneManager.LoadScene("Section5_5Credits"); }

            public void LoadSection5_6Pinball() { SceneManager.LoadScene("Section5_6Pinball"); }

            public void LoadTitleandStages20211130() { SceneManager.LoadScene("TitleandStages20211130"); }

            public void LoadFirstscene() { SceneManager.LoadScene("Firstscene"); }

            public void LoadBoss1() { SceneManager.LoadScene("Boss1"); }

            public void LoadAsobi02() { SceneManager.LoadScene("Asobi02"); }


            public void SetActiveLessonGroup() { lessonGroup.SetActive(true); }
            public void SetDisActiveLessonGroup() { lessonGroup.SetActive(false); }

            public void SetActiveCreateWithUnityGroup() { createWithUnityGroup.SetActive(true); }
            public void SetDisActiveCreateWithUnityGroup() { createWithUnityGroup.SetActive(false); }

            public void SetActiveOtherGroup() { otherGroup.SetActive(true); }
            public void SetDisActiveOtherGroup() { otherGroup.SetActive(false); }


        //授業成果系　ココマデ

        //個人系

    public void LoadGameSelect() { SceneManager.LoadScene("GameSelect"); }

    public void LoadTestClickerScene() { SceneManager.LoadScene("TestClickerScene"); }

    public void LoadJsonClicker() { SceneManager.LoadScene("JsonClicker"); }

    public void LoadGaleemKarinScene() { SceneManager.LoadScene("GaleemKarinScene"); }

    public void LoadMain() { SceneManager.LoadScene("Main"); }

    public void LoadTitleScene() { SceneManager.LoadScene("TitleScene"); }

    public void LoadAchievementsScene() { SceneManager.LoadScene("AchievementsScene"); }

    public void ButtonExit() { Application.Quit(); }



    //個人系　ココマデ

    //LoadScene系　ココマデ

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        //起動したときだけ発生するイベント
        kidouCount++;
        Debug.Log("起動確認: 起動カウント" + kidouCount);
        //起動カウントはセーブデータごとではなく実機ごとにしようかな…？
    }

    void Awake()
    {
        
    }

    void Start()
    {
        debuglogsiro();
        if (SceneManager.GetActiveScene().name == "Section5_3Continue")
        {
            Debug.Log("wafadsc");
        }
        pauseUI.SetActive(false);

        if (SceneManager.GetActiveScene().name == "Prototype 3")
        { 
            //アバター番号を見つけてむこうで照合
            //バリエーション番号をむこうで照合
            //照合したものを
        }
    }

    private void Update()
    {
        isRPressed();
        if (Input.GetButtonDown("Pause"))
        {
            PauseFaction();
        }
    }
    public void PlusCoins(int amount)
    {
        myData.coins += amount;
        coinsText.text = "coins: " + myData.coins.ToString();
        Debug.Log(myData.coins+"コインをゲット");
    }
}

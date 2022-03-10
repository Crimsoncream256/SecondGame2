﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


/*最低限済ませたいこと (いっそのこと色替えは消す/起動カウントの実装も消す)
 * セーブデータの読み込み
 * 各コイン値の設定
 * コイン数表記
 * 各シーンハイスコアの記憶
 * ポーズ画面/設定画面の回転速度変更タブ実装
 * [ｵﾜﾘ]全ゲームシーンにポーズ画面の配置
 * [ｵﾜﾘ]クレジット表記(使用Prefab、参考になったサイトを表記)
 * [進行中]SEManagerの全適用
 */

[System.Serializable]
public class GameManager : MonoBehaviour
{
    [SerializeField] private SpawnManagerU4 s4;

    public int coinsAll;

    [SerializeField] InputField inputArea;
    [SerializeField] Text counterText;
    [SerializeField] bool SecletOpen;
    [SerializeField] static int kidouCount;

    [SerializeField] private GameObject pauseUI;
    public Text coinsText;

    public List<GameObject> series3List;
    public Text series3avaterText;
    public Text series3VariationText;

    public Text scoreU1Text;
    public Text highscoreU1Text;
    public Text highscoreU4Text;

    public Text noticeforNoUsers;

    public int inGameMode;
    [SerializeField] private bool isHighscoreOver;

    public static bool isstartCountAdded;

    [SerializeField] private AudioSource audio;
    public Slider slider;
    [SerializeField] private AudioClip cheers;


    [SerializeField,Header("これがヘッダーの力…！")] string aroha;


    [System.Serializable]
    public class GeneralData
    {//全体セーブデータ
        public string usersName = Environment.UserName;
        public string playerName;
        public int startCount;
        public static bool isStartCountAdded;
    }


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
    }

    PlayerDataG myData = new PlayerDataG();
    GeneralData genData = new GeneralData();

    //Group系

    public GameObject lessonGroup;
    public GameObject createWithCodeGroup;
    public GameObject creditsGroup;
    public GameObject otherGroup;

    //Group系　ココマデ

    //各ゲームハイスコア系

    //各ゲームハイスコア系　ココマデ




    //全体系

    public void debuglogsiro()
    { Debug.Log("?????????????"); }

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
        genData.playerName = playerName;

        string jsonstr = JsonUtility.ToJson(myData);

        writer = new StreamWriter(Application.dataPath + "/save" + playerName + ".json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
        SaveUserData();
    }

    public void SavePlayerData2()
    {
        StreamWriter writer;
        var playerName = genData.playerName;
        myData.playerName = playerName;
        genData.playerName = playerName;

        string jsonstr = JsonUtility.ToJson(myData);

        writer = new StreamWriter(Application.dataPath + "/save" + playerName + ".json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
        SaveUserData();
    }

    public void SaveUserData()
    {
        StreamWriter writer;
        var playerName = Environment.UserName;
        genData.usersName = playerName;
        genData.playerName = myData.playerName;
        Debug.Log("マイデータプレイヤーネーム: " + genData.playerName);

        string jsonstr = JsonUtility.ToJson(genData);

        writer = new StreamWriter(Application.dataPath + "/saveuser" + playerName + ".json", false);
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

    public void LoadPlayerDataUser(string user)
    {
        string datastr = "";
        var playerName = user;
        Debug.Log(user);
        StreamReader reader;

        reader = new StreamReader(Application.dataPath + "/save" + user + ".json");
        datastr = reader.ReadToEnd();
        reader.Close();

        myData = JsonUtility.FromJson<PlayerDataG>(datastr); // ロードしたデータで上書き
        Debug.Log(myData.playerName + "のデータをロードしました");
        counterText.text = myData.clickCount.ToString();
        coinsText.text = "coins: " + myData.coins.ToString();
    }

    public void LoadUsersData()
    {
        Debug.Log("a");
        string datastr = "";
        var playerName = Environment.UserName;
        
        StreamReader reader;

        reader = new StreamReader(Application.dataPath + "/saveuser" + playerName + ".json");
        datastr = reader.ReadToEnd();
        reader.Close();

        genData = JsonUtility.FromJson<GeneralData>(datastr); // ロードしたデータで上書き
        Debug.Log(genData.usersName + "のデータをロードしました");
        Debug.Log("データを読みます: " + genData.playerName);
        LoadPlayerDataUser(genData.playerName);
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


    public void U4HighScore(int U4)
    {
        if(U4 > myData.hsU4)
        {
            myData.hsU4 = U4;
            SavePlayerData2();
        }
    }

    public void setU4Highscore(Text U4)
    {
        U4.text = "ハイスコア: " + myData.hsU4;
    }


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

            public void LoadPrototypes(int num) { SceneManager.LoadScene("Prototype " + num); }

            public void LoadChallenges(int num) { SceneManager.LoadScene("Challenge " + num); }

            public void LoadTitles(int num) { SceneManager.LoadScene("Title" + num); }


        //CreateWithCode系 ココマデ

        //授業成果系

            public void LoadSection5_2() { SceneManager.LoadScene("Section5_2"); }

            public void LoadSection5_3Continue() { SceneManager.LoadScene("Section5_3Continue"); }

            public void LoadSection5_4Settings() { SceneManager.LoadScene("Section5_3Settings"); }

            public void LoadSection5_5Credits() { SceneManager.LoadScene("Section5_5Credits"); }

            public void LoadSection5_6Pinball() { SceneManager.LoadScene("Section5_6Pinball"); }

            public void LoadTitleandStages20211130() { SceneManager.LoadScene("TitleandStages20211130"); }
    
            public void LoadWithEnemies() { SceneManager.LoadScene("WithEnemies"); }

            public void LoadWithItems() { SceneManager.LoadScene("WithItems"); }

            public void LoadWithRivals() { SceneManager.LoadScene("WithRivals"); }
    

            public void LoadFirstscene() { SceneManager.LoadScene("Firstscene"); }

    public void LoadSecondscene() { SceneManager.LoadScene("Secondscene"); }

    public void LoadBoss1() { SceneManager.LoadScene("Boss1"); }

            public void LoadAsobi02() { SceneManager.LoadScene("Asobi02"); }

    /*
            public void SetActiveLessonGroup() { lessonGroup.SetActive(true); }
            public void SetDisActiveLessonGroup() { lessonGroup.SetActive(false); }
    */

            public void SetLessonGroup(bool OnOff) { lessonGroup.SetActive(OnOff); }

    /*
            public void SetActiveCreateWithUnityGroup() { createWithCodeGroup.SetActive(true); }
            public void SetDisActiveCreateWithUnityGroup() { createWithCodeGroup.SetActive(false); }
    */

            public void SetCreateWithCodeGroup(bool OnOff) { createWithCodeGroup.SetActive(OnOff); }

    public void SetCreditGroup(bool OnOff) { creditsGroup.SetActive(OnOff); }


    /*
            public void SetActiveOtherGroup() { otherGroup.SetActive(true); }
            public void SetDisActiveOtherGroup() { otherGroup.SetActive(false); }
    */
    public void SetOtherGroup(bool OnOff) { otherGroup.SetActive(OnOff); }


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

        isstartCountAdded = false;
        Debug.Log(isstartCountAdded);
        GeneralData.isStartCountAdded = isstartCountAdded;
        isstartCountAdded = GeneralData.isStartCountAdded;  



        //起動カウントはセーブデータごとではなく実機ごとにしようかな…？
    }

    void Awake()
    {
        Time.timeScale = 1f;
    }

    void Start()
    {
        Time.timeScale = 1f;
        Debug.Log("タイムスケール: " + Time.timeScale);
        pauseUI.SetActive(false);
        isHighscoreOver = false;
        audio = gameObject.AddComponent<AudioSource>();
        slider.onValueChanged.AddListener(value => this.audio.volume = value);
        LoadUsersData();

        //Debug.Log(GeneralData.isStartCountAdded +" "+ isstartCountAdded);
        debuglogsiro();



        if (SceneManager.GetActiveScene().name == "TitleScene")
        {

            /*
            Debug.Log(isstartCountAdded + "ですのです");

            //SaveUserData();
            LoadUsersData();
            if (genData.startCount == 0)
            {
                Debug.Log("ようこそ: " + genData.startCount);
                noticeforNoUsers.text = "初めて起動したときはこのボタンを押してください";
                //SaveUserData();
            }

            //もうむり　2022/03/08

            if (isstartCountAdded == false)
            {
                Debug.Log("にゃ");
                int a = 1;
                genData.startCount += a;
                isstartCountAdded = true;
                GeneralData.isStartCountAdded = isstartCountAdded;
                Debug.Log(GeneralData.isStartCountAdded + " " + isstartCountAdded);
                Debug.Log("起動確認: 起動カウント" + genData.startCount);
            } else if (GeneralData.isStartCountAdded)
            {
                Debug.Log("起動カウント追加済み");
            }
            /*
            StreamWriter writer;
            var playerName = Environment.UserName;
            Debug.Log("mydataPlayerName: " + myData.playerName);

            string jsonstr = JsonUtility.ToJson(genData);

            writer = new StreamWriter(Application.dataPath + "/saveuser" + playerName + ".json", false);
            writer.Write(jsonstr);
            writer.Flush();
            writer.Close();
            */
        }

        if (SceneManager.GetActiveScene().name == "Section5_3Continue")
        {
            Debug.Log("wafadsc");
        }


        if (SceneManager.GetActiveScene().name == "Prototype 3")
        { 
            //アバター番号を見つけてむこうで照合
            //バリエーション番号をむこうで照合
            //照合したものを
        }

        if (SceneManager.GetActiveScene().name == "Title4")
        {
            highscoreU4Text.text = "ハイスコア: ";
        }


    }

    void Update()
    {
        isRPressed();
        if (Input.GetButtonDown("Pause"))
        {
            PauseFaction();
        }

        if (SceneManager.GetActiveScene().name == "Prototype 4")
        {
            if (myData.hsU4 < s4.waveNumber && !(isHighscoreOver))
            {
                audio.PlayOneShot(cheers);
                Debug.Log("ｵﾒﾃﾞﾄｰ!!!!!!!!!!!!!!!!!!!!!!!!!");
                isHighscoreOver = true;
            }
        }

    }
    public void PlusCoins(int amount)
    {
        myData.coins += amount;
        Debug.Log(myData.coins + "コインをゲット");
        coinsText.text = "coins: " + myData.coins.ToString();
    }

    public void PlusCoinsInGame(int amount)
    {
        coinsAll += amount;
        Debug.Log(coinsAll + "コインをゲット");
    }

    public void PlusCoinsAll()
    {
        myData.coins += coinsAll;
        Debug.Log(coinsAll+"コインをゲット");
        Debug.Log(myData.coins + "コイン");
        coinsAll = 0;
    }
}

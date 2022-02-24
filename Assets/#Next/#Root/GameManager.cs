using System.Collections;
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

    [System.Serializable]
    public class PlayerDataG
    {
        public int clickCount;
        public string playerName;
        public bool SecletOpened;
    }

    PlayerDataG myData = new PlayerDataG();

    //Group系

    public GameObject lessonGroup;
    public GameObject createWithUnityGroup;
    public GameObject otherGroup;

    //Group系　ココマデ



    public void OnClickEvent()
    {
        myData.clickCount++;
        counterText.text = myData.clickCount.ToString();
    }

    public void isSecletOpened()
    {
        SecletOpen = true;
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
    }

    //LoadScene系

    //CreateWithUnity系
    public void LoadPrototype1()
<<<<<<< HEAD

        //これはこっち

    { SceneManager.LoadScene("Prototype 1"); }

    public void LoadPrototype2()
    { SceneManager.LoadScene("Prototype 2"); }

    public void LoadPrototype3()
    { SceneManager.LoadScene("Prototype 3"); }

    public void LoadPrototype4()
    { SceneManager.LoadScene("Prototype 4"); }

    public void LoadPrototype5()
    { SceneManager.LoadScene("Prototype 5"); }

    public void LoadChallenge1()
    { SceneManager.LoadScene("Challenge 1"); }

    public void LoadChallenge2()
    { SceneManager.LoadScene("Challenge 2"); }

    public void LoadChallenge3()
    { SceneManager.LoadScene("Challenge 3"); }

    public void LoadChallenge4()
    { SceneManager.LoadScene("Challenge 4"); }

    public void LoadChallenge5()
    { SceneManager.LoadScene("Challenge 5"); }

    public void LoadTitle1()
    { SceneManager.LoadScene("Title1"); }

    public void LoadTitle2()
    { SceneManager.LoadScene("Title2"); }

    public void LoadTitle3()
    { SceneManager.LoadScene("Title3"); }

    public void LoadTitle4()
    { SceneManager.LoadScene("Title4"); }

    public void LoadTitle5()
    { SceneManager.LoadScene("Title5"); }
=======
    { SceneManager.LoadScene("Prototype1"); }

    public void LoadPrototype2()
    { SceneManager.LoadScene("Prototype2"); }

    public void LoadPrototype3()
    { SceneManager.LoadScene("Prototype3"); }

    public void LoadPrototype4()
    { SceneManager.LoadScene("Prototype4"); }

    public void LoadPrototype5()
    { SceneManager.LoadScene("Prototype5"); }

    public void LoadChallenge1()
    { SceneManager.LoadScene("Challenge1"); }

    public void LoadChallenge2()
    { SceneManager.LoadScene("Challenge2"); }

    public void LoadChallenge3()
    { SceneManager.LoadScene("Challenge3"); }

    public void LoadChallenge4()
    { SceneManager.LoadScene("Challenge4"); }

    public void LoadChallenge5()
    { SceneManager.LoadScene("Challenge5"); }
>>>>>>> master

    //CreateWithUnity系 ココマデ

    //授業成果系

    public void LoadSection5_2()
    { SceneManager.LoadScene("Section5_2"); }

    public void LoadSection5_3Continue()
    { SceneManager.LoadScene("Section5_3Continue"); }

    public void LoadSection5_4Settings()
    { SceneManager.LoadScene("Section5_3Settings"); }

    public void LoadSection5_5Credits()
    { SceneManager.LoadScene("Section5_5Credits"); }

    public void LoadSection5_6Pinball()
    { SceneManager.LoadScene("Section5_6Pinball"); }

    public void LoadTitleandStages20211130()
    { SceneManager.LoadScene("TitleandStages20211130"); }

    public void LoadFirstscene()
    { SceneManager.LoadScene("Firstscene"); }

    public void LoadBoss1()
    { SceneManager.LoadScene("Boss1"); }

    public void LoadAsobi02()
    { SceneManager.LoadScene("Asobi02"); }


    public void SetActiveLessonGroup()
    {
        //Debug.Log("じゃどｊ");
        lessonGroup.SetActive(true);
    }

    public void debuglogsiro()
    {
        Debug.Log("?????????????");
    }

    public void SetDisActiveLessonGroup()
    {
        lessonGroup.SetActive(false);
    }

    public void SetActiveCreateWithUnityGroup()
    {
        createWithUnityGroup.SetActive(true);
    }

    public void SetDisActiveCreateWithUnityGroup()
    {
        createWithUnityGroup.SetActive(false);
    }

    public void SetActiveOtherGroup()
    {
        otherGroup.SetActive(true);
    }

    public void SetDisActiveOtherGroup()
    {
        otherGroup.SetActive(false);
    }


    //授業成果系　ココマデ

    //個人系

    public void LoadGameSelect()
    { SceneManager.LoadScene("GameSelect"); }

    public void LoadTestClickerScene()
    { SceneManager.LoadScene("TestClickerScene"); }

    public void LoadJsonClicker()
    { SceneManager.LoadScene("JsonClicker"); }

    public void LoadGaleemKarinScene()
    { SceneManager.LoadScene("GaleemKarinScene"); }

    public void LoadMain()
    { SceneManager.LoadScene("Main"); }

    public void LoadTitleScene()
    { SceneManager.LoadScene("TitleScene"); }

    public void LoadAchievementsScene()
    { SceneManager.LoadScene("AchievementsScene"); }

    public void ButtonExit()
    { UnityEngine.Application.Quit(); }



    //個人系　ココマデ

    //LoadScene系　ココマデ



    void Awake()
    {
        
    }

    void Start()
    {
        debuglogsiro();
    }
}

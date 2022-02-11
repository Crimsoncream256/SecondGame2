using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//[System.Serializable]//セーブデータ作りたかった

public class GameManager : MonoBehaviour
{
    public int PressedX;

    public int life;
    public int DefaultLife;
    public int Tamakazu;
    public int DefaultTamakazu;
    private Text Nokori;

    public List<int> StageHighScore = new List<int>();
    public List<bool> IsStageCleared = new List<bool>();
    public List<string> StageNames = new List<string>();

    public GameObject StageButton1;
    public GameObject StageButton2;
    public GameObject StageButton3;
    public GameObject StageButton4;
    public GameObject BossButton1;
    public GameObject SecletButton1;

    public GameObject ballPrefab;
    public Text textGameOver;
    public Text textClear;
    public Text textKatarite;

    public GameObject TitleButton;
    public GameObject RetlyButton;
    public GameObject SelectButton;
    public GameObject NextButton;

    private int score;

    private Text textScore;
    private Text textHighScore;

    GameObject[] tagObjects;

    public GameObject ResultPanel;
    private Text textResult;
    private Text textResultBall;
    private Text textResultTime;
    private Text textResultTotal;

    private int fAllen;
    private int bRoken;
    private Text fallenText;
    private Text brokenText;

    private float leftTime;
    private Text textTimer;

    private AudioSource audioSource;
    public AudioClip overSound;
    public AudioClip killSound;
    public AudioClip clearSound;



    public Text STAGE1;
    public Text STAGE2;
    public Text STAGE3;
    public Text STAGE4;
    public Text BOSS1;
    public Text SECLET1;

    //セーブしたい
    public bool S1Open = true;
    public bool S2Open = false;
    public bool S3Open = false;
    public bool S4Oen = false;
    public bool B1Open = false;
    public bool Sc1Cleared = true;

    static int highScore = 0;
    static int Play = 1;

    public int Kidoued = 0;
    //セーブしたい　ココマデ


    private bool inGame;
    public int CLEAREDSwitch;

    
    //最初の設定
    void Start()
    {
        //値設定
        score = 0;
        Kidoued += 1;
        PressedX = 0;

        if (SceneManager.GetActiveScene().name == "Section5_3Continue")
        {
            STAGE1.text = "ステージ1\n肩慣らし";
            STAGE2.text = "ステージ2\nちょっと広め";
            STAGE3.text = "ステージ3\n爆裂球！";
            STAGE4.text = "ステージ4\nパズル";
            BOSS1.text = "ボスステージ1\nオレサマ";
            SECLET1.text = "ステージX\n挑戦状";
        }




        //見つける・設定
        audioSource = gameObject.AddComponent<AudioSource>();



        textScore = GameObject.Find("Score").GetComponent<Text>();
        SetScoreText(score);

        fallenText = GameObject.Find("Fallen").GetComponent<Text>();
        SetFallenText(fAllen);

        brokenText = GameObject.Find("Broken").GetComponent<Text>();
        SetBrokenText(bRoken);




        textResult = GameObject.Find("ResultScore").GetComponent<Text>();
        textResultBall = GameObject.Find("ResultBall").GetComponent<Text>();
        textResultTime = GameObject.Find("ResultTime").GetComponent<Text>();
        textResultTotal = GameObject.Find("ResultTotal").GetComponent<Text>();

        textHighScore = GameObject.Find("HighScore").GetComponent<Text>();
        SetHighScoreText(highScore);

        //隠す
        textResult.enabled = false;
        textResultBall.enabled = false;
        textResultTime.enabled = false;
        textResultTotal.enabled = false;

        textGameOver.enabled = false;
        textClear.enabled = false;

        TitleButton.SetActive(false);
        RetlyButton.SetActive(false);
        SelectButton.SetActive(false);
        NextButton.SetActive(false);

        ResultPanel.SetActive(false);

        //inGame
        inGame = true;

        if (SceneManager.GetActiveScene().name == "Stage1")

        {
            leftTime = 100f;
            textTimer = GameObject.Find("TimeText").GetComponent<Text>();
            textKatarite.text = "ようこそ、100秒フッとばしチャレンジへ！ナレーター役のオレサマだ！\n←→キーでうごけるぞ！\n壊せるもんはぜーんぶブッ壊せ！ガーッハッハ！";
            life = 15;
            DefaultTamakazu = 1;
            SaishoNoAre();
        }
        else if (SceneManager.GetActiveScene().name == "Stage2")
        {
            leftTime = 100f;
            textTimer = GameObject.Find("TimeText").GetComponent<Text>();
            textKatarite.text = "ちょっとだけ広くしてみたぜ！操作方法は覚えただろうし、ライフ10くらいでもいいだろ？";
            life = 10;
            DefaultTamakazu = 1;
            SaishoNoAre();
        }
        else if (SceneManager.GetActiveScene().name == "Stage3")
        {
            leftTime = 100f;
            textTimer = GameObject.Find("TimeText").GetComponent<Text>();
            textKatarite.text = "おっ！その宝玉は爆裂球だ！取ってくれたらブロックぜーんぶ壊してやるぜ！\nとりあえずライフは5にしといたぜ！ま、がんばれよ！ガーッハッハ！";
            life = 5;
            DefaultTamakazu = 1;
            SaishoNoAre();
        }
        else if (SceneManager.GetActiveScene().name == "Stage4")
        {
            leftTime = 100f;
            textTimer = GameObject.Find("TimeText").GetComponent<Text>();
            textKatarite.text = "げーっ、散らかってんなー！あの青いやつにぶつけてくれれば、爆裂球を出してやるよ！\nとりあえず今回もライフは5な！";
            life = 10;
            DefaultTamakazu = 1;
            SaishoNoAre();
        }
        else if (SceneManager.GetActiveScene().name == "Boss1")
        {
            leftTime = 100f;
            textTimer = GameObject.Find("TimeText").GetComponent<Text>();
            textKatarite.text = "いぇーい！遊びに来たぜーっ！いわゆるボス戦ってやつだ！ま、手加減はするからキンチョーするなよ！\n\nその赤い球はオレサマの弾幕だ！あたると熱いぞ！";
            life = 15;
            DefaultTamakazu = 2;
            SaishoNoAre();
        }
        else if (SceneManager.GetActiveScene().name == "Seclet1")
        {
            leftTime = 300f;
            textTimer = GameObject.Find("TimeText").GetComponent<Text>();
            textKatarite.text = "ようこそオレサマの巣窟へ！遊びに来てくれてありがとーな！\n\nさあ、今回は手加減しねーぞ！どれだけやれるか、オマエの力見せてみろ！\n\n心の準備ができたらそこの青いのに乗りな、ボールを出してやる！";
            life = 150;
            DefaultTamakazu = 4;
            SaishoNoAre();
        }
        else
        {
            textKatarite.text = "ここはどこだッ?!オレサマの知らない場所だぞー！\nま、いっか！ふっとばしてってくれー！";
            life = 15;
            SaishoNoAre();
        }

        Nokori = GameObject.Find("Nokori").GetComponent<Text>();
        SetNokoriText(life);

        audioSource.PlayOneShot(clearSound);
    }




    //定義欄

    //未分類

    private void SaishoNoAre()
    {
        CLEAREDSwitch = 0;
        DefaultLife = life;
    }

    private void GameoverSwitch()
    {
        audioSource.PlayOneShot(overSound);
        textGameOver.enabled = true;
        CLEAREDSwitch = -1;
        inGame = false;
    }

    public void check(string tagname)
    {
        tagObjects = GameObject.FindGameObjectsWithTag(tagname);
        Debug.Log(tagObjects.Length); //tagObjects.Lengthはオブジェクトの数
        if (tagObjects.Length < DefaultTamakazu)
        {
            Debug.Log(tagname + "タグがついてるobjが少ない");
            --life;
            SetNokoriText(life);
            audioSource.PlayOneShot(killSound);
            GameObject newBall = Instantiate(ballPrefab);
            newBall.name = ballPrefab.name;
            if (life > 0)
            {
                if (life == 14 || life == 15)
                {
                    textKatarite.text = "ガッハッハ！どんどんフッとばしてけ！\nなんたってのこりは14もあるからな！";
                }
                else if (life < 4)
                {
                    textKatarite.text = "逆境こそ燃える!!\nそう思うだろ？";
                }
                else
                {
                    textKatarite.text = "いいぞいいぞー！！\nフッとばせー！";
                }
            }
            else
            {
                life = 0;
                SetNokoriText(life);
                GameoverSwitch();
                textKatarite.text = "ガッハッハ！\nいいフッとばしっぷりだったぜ！もっかい挑戦するか？";
            }
        }
    }

    //未分類　ココマデ


    //スコア系
    private void SetScoreText(int score)
    { textScore.text = "スコア:" + score.ToString(); }

    public void AddScore(int point)
    {
        if (inGame)
        {
            score += point;
            SetScoreText(score);
        }
    }

    private void SetHighScoreText(int highscore)
    {
        textHighScore.text = "ハイスコア:" + highScore.ToString();
    }
    //スコア系　ココマデ


    //残機系
    private void SetNokoriText(int life)
    {
        Nokori.text = "のこり" + life.ToString() + "コ";
    }
    public void BallDelete()
    {
        --life;
        SetNokoriText(life);
    }
    //残機系　ココマデ


    //落とした・壊した(参考: スコア系)
    public void AddFallen(int FP)
    {
        fAllen += FP;
        SetFallenText(fAllen);
    }
    public void SetFallenText(int fAllen)
    {
        fallenText.text = "おとした:" + fAllen;
    }
    
    public void AddBroken(int BP)
    {
        bRoken += BP;
        SetBrokenText(bRoken);
    }
    public void SetBrokenText(int bRoken)
    {
        brokenText.text = "こわした:" + bRoken;
    }
    //落とした・壊した　ココマデ



    //タイトルボタン系　ココカラ

    public void ButtonStart()
    { SceneManager.LoadScene("Stage1"); }

    public void ButtonStage2()
    { SceneManager.LoadScene("Stage2"); }

    public void ButtonStage3()
    { SceneManager.LoadScene("Stage3"); }

    public void ButtonStage4()
    { SceneManager.LoadScene("Stage4"); }

    public void ButtonBoss1()
    { SceneManager.LoadScene("Boss1"); }

    public void ButtonSeclet1()
    { SceneManager.LoadScene("Seclet1"); }

    
    public void ButtonRetly()
    { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }

    public void ButtonContinue()
    { SceneManager.LoadScene("Section5_3Continue"); }

    public void ButtonSettingS()
    { SceneManager.LoadScene("Section5_4Settings"); }

    public void ButtonCredits()
    { SceneManager.LoadScene("Section5_5Credits"); }

    public void ButtonTitle()
    { SceneManager.LoadScene("Section5_2"); }

    public void ButtonExit()
    { UnityEngine.Application.Quit(); }

    //タイトルボタン系　ココマデ




    //定義欄　ココマデ






    //ココカラ
    void Update()
    {


            if (inGame == true) {

            check("Ball");

            leftTime -= Time.deltaTime;
            textTimer.text = "Time:" + (leftTime > 0f? leftTime.ToString("0.00"):"0.00");
            if (leftTime < 75f && life <= 1)
            {
                textKatarite.text = "ガッハッハッハ…さあ、逆転してみせろよ？";
            }
            else if (leftTime < 75f && life >= DefaultLife)
            {
                textKatarite.text = "お、シンチョーだな！\nのこりはたくさんあるんだから、ガンガンフッとばしてってもいいんだぜ？";
            } else if (leftTime < 75f && leftTime >74f && SceneManager.GetActiveScene().name == "Stage2")
            {
                textKatarite.text = "そうそう、Shiftキーを押したらちょっと遅く移動できるぜ！お試しあれ！";
            }
            if (leftTime < 50f && leftTime > 49f)
            {
                textKatarite.text = "時間残り半分だ！\nつってもほとんどキレイそうだけどな！";
            }else if(leftTime < 0f)
            {
                GameoverSwitch();
                textKatarite.text = "ガッハッハ！時間切れだ！\nあきらめなかったお前に敬礼するぞ！\n(｀･ｗ･´)ゞ";
            }
            GameObject targetObj = GameObject.FindWithTag("KABE");
            if (targetObj == null)
            {
                audioSource.PlayOneShot(clearSound);
                
                textClear.enabled = true;
                CLEAREDSwitch = 1;
                
                
                //計算
                int scorePoint = score * 50;
                int scoreBall = life * 500;
                int scoreTime = (int)(leftTime * 100f);

                textResult.enabled = true;
                textResultBall.enabled = true;
                textResultTime.enabled = true;
                textResultTotal.enabled = true;
                ResultPanel.SetActive(true);

                textResult.text = "Score * 50 = " + scorePoint.ToString();
                textResultBall.text = "Ball * 500 = " + scoreBall.ToString();
                textResultTime.text = "Time * 100 = " + scoreTime.ToString();

                int totalScore = scorePoint + scoreBall + scoreTime;
                textResultTotal.text = "Total Score: " + totalScore.ToString();

                if (SceneManager.GetActiveScene().name == "Seclet1")
                {
                    textKatarite.text = "おいおい！ウッソだろ！オレサマこれならぜーったい勝てると思ってたぞ！まさかボールを"+ life + "コも残して勝つなんて！\nま、それよりたくさん一緒に遊んでくれて、ホントにありがとーな！";
                } else if (SceneManager.GetActiveScene().name == "Boss1")
                {
                    textKatarite.text = "おめでとー！今んとこラスボスのオレサマ撃破だ！さすが俺の見込んだものだ！\n\n一緒に遊んでくれてありがとーな！すっげーたのしかったぜ！なあ、もしよかったらまた遊びに来てくれよ！";
                }
                else if (life == 1 && DefaultLife == 1)
                {
                    textKatarite.text = "うぉー！まさか本当に逆転しちまうなんて！すごいの一言じゃ足りねーや！！誇ってもいいんだぞー！";
                }
                else if (life == DefaultLife && highScore < totalScore && Play == 1 && SceneManager.GetActiveScene().name == "Stage3")
                {
                    textKatarite.text = "うぉー！さすがだ！一回も死なずに爆裂球を取ってくれるなんて！すばらしいかぎりだ！ガーッハッハ！";
                }
                else if (life == DefaultLife && highScore < totalScore && Play == 1)
                {
                    textKatarite.text = "オマエ…さては初見じゃないな？初見でふっとばないのはきっと難しいはずだ！\nだがその力は認める！おめでとう！ガーッハッハ！";
                }
                else if (life == DefaultLife && highScore < totalScore)
                {
                    textKatarite.text = "なんてこった！\nまさか1回もフッとばずにハイスコアを更新するなんて！おめでとう！\n開いた口がふさがらないぜ！ガーッハッハ！";
                }
                else if(highScore < totalScore)
                {
                    textKatarite.text = "ガッハッハ！ハイスコア更新だ！\n栄えある今回のハイスコアは…" + totalScore.ToString() + "だ！";
                }
                else if (life == DefaultLife) 
                {
                    textKatarite.text = "マジかよ？どうやってやったんだ？？";
                }
                else 
                {
                    textKatarite.text = "ガッハッハ！やりとげたな！さすがだ！\n今回のスコアは" + totalScore.ToString() + "だ！";
                }


                if (highScore < totalScore)
                {
                    highScore = totalScore;
                }
                inGame = false;
            }
            
        }

        if (inGame == false)
        {
            if (CLEAREDSwitch == -1)
            {
                TitleButton.SetActive(true);
                RetlyButton.SetActive(true);
                SelectButton.SetActive(true);
            }
            else if(CLEAREDSwitch == 1)
            {
                TitleButton.SetActive(true);
                RetlyButton.SetActive(true);
                SelectButton.SetActive(true);
                NextButton.SetActive(true);
            }
            else if (CLEAREDSwitch == 0)
            {
                //何もしないには何も書かなければいいのか
            }else
            {
                textKatarite.text = "げっしまった！入れ忘れだッ！すまねェが、あのあほ制作者にどこでエラーがあったか連絡してくれねぇか？\nTwitter: CrimsonCream256\nMail: Crimsoncream256@gmail.com";
            }


        }
    }
}
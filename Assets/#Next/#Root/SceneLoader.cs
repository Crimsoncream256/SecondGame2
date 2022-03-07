using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

[CreateAssetMenu]
public class SceneLoader : ScriptableObject
{
    public void debuglogsiro()
    { Debug.Log("?????????????"); }

    public void Retry()
    { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }

    public void LoadPrototypes(int num) { SceneManager.LoadScene("Prototype " + num); }

    public void LoadChallenges(int num) { SceneManager.LoadScene("Challenge " + num); }

    public void LoadTitles(int num) { SceneManager.LoadScene("Title" + num); }


    public void LoadSection5_2() { SceneManager.LoadScene("Section5_2"); }

    public void LoadSection5_3Continue() { SceneManager.LoadScene("Section5_3Continue"); }

    public void LoadSection5_4Settings() { SceneManager.LoadScene("Section5_3Settings"); }

    public void LoadSection5_5Credits() { SceneManager.LoadScene("Section5_5Credits"); }

    public void LoadSection5_6Pinball() { SceneManager.LoadScene("Section5_6Pinball"); }

    public void LoadTitleandStages20211130() { SceneManager.LoadScene("TitleandStages20211130"); }

    public void LoadFirstscene() { SceneManager.LoadScene("Firstscene"); }

    public void LoadBoss1() { SceneManager.LoadScene("Boss1"); }

    public void LoadAsobi02() { SceneManager.LoadScene("Asobi02"); }


}

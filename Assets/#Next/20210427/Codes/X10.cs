using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class X10 : MonoBehaviour
{
    //public GameManager manager;
    public bool onOff;

    public int PressedX;
    public GameObject XButton;

    public AudioSource audiO;
    public AudioClip Tada;

    void Start()
    {
        PressedX = 0;
        XButton.SetActive(false);
        audiO = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Section5_3Continue")
        {

            if (Input.GetKeyDown(KeyCode.X))
            {
                PressedX += 1;
                if (PressedX >= 10)
                {
                    if (PressedX == 10)
                    {
                        GameObject gm = GameObject.Find("GOD");
                        //gm.GetComponent<GameManager>().isSecletOpened();
                        audiO.PlayOneShot(Tada);
                        Debug.Log("隠しステージ開放");
                        XButton.SetActive(true);
                    }
                }
            }
        }
    }
}

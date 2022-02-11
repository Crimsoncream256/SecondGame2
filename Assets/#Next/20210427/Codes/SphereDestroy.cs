using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereDestroy : MonoBehaviour
{
    private new AudioSource audio;
    public AudioClip Cheers;

    private Text C_text;

    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
        this.C_text = GameObject.Find("Getthecrown").GetComponent<Text>(); // textコンポーネントを取得
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "crown")
        {
            C_text.text = "おうかんをてにいれた！";
            audio.PlayOneShot(Cheers);
        }
    }
    void Update()
    {



        if (transform.position.y <= -15)
        {
            Destroy(this.gameObject);
        }
    }
}

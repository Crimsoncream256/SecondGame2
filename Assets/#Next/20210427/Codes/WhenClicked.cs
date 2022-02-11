using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhenClicked : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip Meow;

    private Text C_text;

    public GameObject Sphere;
    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
        audio.PlayOneShot(Meow); 
        this.C_text = GameObject.Find("Getthecrown").GetComponent<Text>(); // textコンポーネントを取得
        C_text.text = "カベをこわして、おうかんをてにいれよう！";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float x = Random.Range(180.0f, 200.0f);
            float y = Random.Range(60.0f, 90.0f);
            float z = Random.Range(-2.0f, 2.0f);

            //オブジェクトを生産
            Instantiate(Sphere, new Vector3(x, y, z), Quaternion.identity);
        }
    }
}

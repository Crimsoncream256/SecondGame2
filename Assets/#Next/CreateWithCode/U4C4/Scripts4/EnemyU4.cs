using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyU4 : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    
    public float speed;
    public Rigidbody enemyRb;
    private GameObject player;

    [SerializeField] private AudioSource audio;
    [SerializeField] private Slider slider;
    [SerializeField] private AudioClip slip;



    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GOD").GetComponent<GameManager>();
        player = GameObject.Find("Player");
        audio = gameObject.AddComponent<AudioSource>();
        Slider slider = GameObject.Find("SeSlider").GetComponent<Slider>();

        slider.onValueChanged.AddListener(value => this.audio.volume = value);
        enemyRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);
        if(transform.position.y < -10) 
        {
            gm.PlusCoins(5);
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            audio.PlayOneShot(slip);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerU4 : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    [SerializeField] private GameObject focalPoint;
    [SerializeField] private float speed = 1f;
    [SerializeField] private SpawnManagerU4 s4;
    private Rigidbody playerRb;
    public bool hasPowerup;
    private float PowerupStrength = 15.0f;
    public GameObject powerupIndicator;

    [SerializeField] private AudioSource audio;
    public Slider slider;
    [SerializeField] private AudioClip small;
    [SerializeField] private AudioClip big;
    [SerializeField] private AudioClip slip;

    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
        slider.onValueChanged.AddListener(value => this.audio.volume = value);
        playerRb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, 0.5f, 0);
        if (transform.position.y < -10)
        {
            gm.U4HighScore(s4.waveNumber);
            Debug.Log("これにて終了");
            gm.inGameMode = -1;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {

            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("プレイヤーが" + collision.gameObject + "にぶつかったぞー(" + hasPowerup + ")");
            enemyRigidbody.AddForce(awayFromPlayer *enemyRigidbody.mass * PowerupStrength, ForceMode.Impulse);
            audio.PlayOneShot(big);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            audio.PlayOneShot(small);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            audio.PlayOneShot(slip);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        Debug.Log("オワリ");
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}

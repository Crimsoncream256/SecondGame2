using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerU4 : MonoBehaviour
{
    [SerializeField] private GameObject focalPoint;
    [SerializeField] private float speed = 1f;
    private Rigidbody playerRb;
    public bool hasPowerup;
    private float PowerupStrength = 15.0f;
    public GameObject powerupIndicator;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, 0.5f, 0);
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
            enemyRigidbody.AddForce(awayFromPlayer * PowerupStrength, ForceMode.Impulse);
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

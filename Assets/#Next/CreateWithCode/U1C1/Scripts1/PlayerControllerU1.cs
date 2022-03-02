using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerU1 : MonoBehaviour
{
    public float speed = 20.0f;
    public float turnSpeed = 45f;

    public GameManager gm;
    public bool gameOver;

    void Start()
    {
        
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * turnSpeed);
    }

    /*
    void gameOver01()
    {

    }
    */

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            /*
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            */
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        }

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            /*
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            */
            Destroy(other.gameObject);

        }
        else if (other.gameObject.CompareTag("Kill") && !gameOver)
        {
            gm.Retry();
        }

    }
}

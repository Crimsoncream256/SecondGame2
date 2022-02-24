using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetU5 : MonoBehaviour
{
    private GameManagerU5 gameManager;

    public ParticleSystem explosionParticle;

    private Rigidbody targetRb;

    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxtorque = 10;
    private float xRange = 4;
    float ySpawnPos = -6;
    public int pointValue;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManagerU5>();
        Vector3 RandomForce() { return Vector3.up * Random.Range(minSpeed, maxSpeed); }
        float RandomTorque() { return Random.Range(-maxtorque, maxtorque); }
        Vector3 RandomSpawnPos() { return new Vector3(Random.Range(-xRange, xRange), ySpawnPos); }

        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();  
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position,explosionParticle.transform.rotation); ;
            gameManager.UpdateScore(pointValue);
        } }

    private void OnTriggerEnter(Collider other)
    { 
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }




    void Update()
    {
        
    }
}

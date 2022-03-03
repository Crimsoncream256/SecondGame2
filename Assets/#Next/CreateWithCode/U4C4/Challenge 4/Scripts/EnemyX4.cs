using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX4 : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject playerGoal;

    private SpawnManagerX4 sp4;
    private GameManagerX4 gm4;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player Goal");
        sp4 = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX4>();
        gm4 = GameObject.Find("GOD").GetComponent<GameManagerX4>();
        speed = sp4.enemySpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            gm4.score += 10;
            //coin++
            gm4.check();
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

}

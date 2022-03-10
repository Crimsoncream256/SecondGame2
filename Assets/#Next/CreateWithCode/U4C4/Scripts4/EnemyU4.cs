using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyU4 : MonoBehaviour
{
    public GameManager gm;
    
    public float speed;
    public Rigidbody enemyRb;
    private GameObject player;

    

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
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
}

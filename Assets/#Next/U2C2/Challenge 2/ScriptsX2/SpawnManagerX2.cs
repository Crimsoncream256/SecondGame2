using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX2 : MonoBehaviour
{
    public List<GameObject> ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
        // Generate random ball index and random spawn position
        Debug.Log("出現");
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Debug.Log("複製");
        int ballIndex = Random.Range(0, ballPrefabs.Count);
        GameObject ball = ballPrefabs[ballIndex];
        Instantiate(ball, spawnPos, ball.transform.rotation);
    }

}

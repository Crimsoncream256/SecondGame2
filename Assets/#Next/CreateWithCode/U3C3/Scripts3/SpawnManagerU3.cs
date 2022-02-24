using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerU3 : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float repeatRate = 2;
    private float passedTime = -2f;
    private PlayerControllerU3 playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerControllerU3>();
    }

    void Update()
    {
        if (playerController.gameOver)
        {
            return;
        }

        passedTime += Time.deltaTime;
        if (passedTime > repeatRate)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
            passedTime = 0f;
        }

    }


}

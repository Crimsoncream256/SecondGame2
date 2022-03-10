using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManagerU4 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    [SerializeField] private Text waveAmount;
    [SerializeField] private GameManager gm;
    [SerializeField] private Text HighScore;


    private float spawnRange = 9;

    public int enemyCount;
    public int waveNumber = 1;


    // Start is called before the first frame update
    void Start()
    {
        waveAmount.text = "生き残りウェーブ数: " + waveNumber.ToString();
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        gm.setU4Highscore(HighScore);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++ )
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyU4>().Length;
        if(enemyCount == 0 && !(gm.inGameMode == -1))
        {
            waveAmount.text = "生き残りウェーブ数: " + waveNumber.ToString();
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }
}

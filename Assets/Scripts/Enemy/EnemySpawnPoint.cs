using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    public GameObject[] enemys;
    public Transform[] spawnPoints;
    public float spawnDelay;
    public float maxSpawnDelay = 2.5f;

    //public GameObject player;
    void Update()
    {
        spawnDelay += Time.deltaTime;
        if (spawnDelay >= maxSpawnDelay)
        {
            EnemysSpawn();
            maxSpawnDelay = Random.Range(2f, 2.5f);
            spawnDelay = 0;
        }
    }

    void EnemysSpawn()
    {
        //Debug.Log("EnemySpawn!");
        int randomEnemy = Random.Range(0, enemys.Length);
        int ranPoint = Random.Range(0, spawnPoints.Length);
        

        Instantiate(enemys[randomEnemy], spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);
    }
    
}

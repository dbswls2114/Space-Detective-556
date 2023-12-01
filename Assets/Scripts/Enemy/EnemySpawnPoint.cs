using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    public GameObject[] enemys;
    public Transform[] spawnPoints;
    public float spawnDelay;
    public float maxSpawnDelay = 1.6f;
    void Start()
    {

    }

    void Update()
    {
        spawnDelay += Time.deltaTime;
        if (spawnDelay >= maxSpawnDelay)
        {     
            EnemysSpawn();
            spawnDelay = 0;
        }
    }

    void EnemysSpawn()
    {
        Debug.Log("EnemySpawn!");
        int randomEnemy = Random.Range(0, enemys.Length);
        int ranPoint = Random.Range(0, spawnPoints.Length);

        Instantiate(enemys[randomEnemy], spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);
    }

    IEnumerator ForceMove()
    {
        //pos += Vector2.down * 0.01f;
        int ranPointY = Random.Range(1, 4);
        int ranPointX = Random.Range(-2, 2);
        Vector2 ranVec = new Vector2(ranPointX, ranPointY);
        transform.DOMove(ranVec, 2);
        yield return null;
    }

    //IEnumerator ForwardMoveEnemy()
    //{
    //    int randomEnemy = Random.Range(0, enemys.Length);

    //    enemys[randomEnemy].transform.position = Vector2.up * -10;
    //    yield return null;
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    public static float spawnRate;
    public static int NumberOfEnemies;

    private float x, y;
    private int counting;
    private Vector3 spawnPos;

    void Start()
    {
        NumberOfEnemies = 5;
        spawnRate = 2;
        counting = 0;
        StartCoroutine(SpawnTestEnemy());
    }

    public IEnumerator SpawnTestEnemy()
    {
        x = Random.Range(-5, 5);
        y = Random.Range(-5, 5);
        spawnPos.x += x;
        spawnPos.y += y;
        Instantiate(Enemies[0], spawnPos, Quaternion.identity);
        counting += 1;
        yield return new WaitForSeconds(spawnRate);
        if (counting < NumberOfEnemies)
        {
            StartCoroutine(SpawnTestEnemy());
        } else
        {
            while(counting >= NumberOfEnemies)
            {
                yield return new WaitForSeconds(1);
            }
            StartCoroutine(SpawnTestEnemy());
        }
    }
}

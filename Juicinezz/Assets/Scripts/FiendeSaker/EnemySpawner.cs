using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab = null;
    [SerializeField] float spawnIntervalTime = 0.5f;
    [SerializeField]Vector3 spawnCords = new Vector3();

    int spawnCount = 0;
    float timer = 0f;

    private void Update()
    {
        if(spawnCount > 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                Instantiate(enemyPrefab, spawnCords, Quaternion.identity);
                spawnCount--;
                timer = spawnIntervalTime;
            }
        }
    }

    public void SpawnEnemySet(int enemies)
    {
        spawnCount = enemies;
        timer = spawnIntervalTime;
    }
}

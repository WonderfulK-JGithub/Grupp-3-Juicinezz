using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner current = null;

    [SerializeField] GameObject[] enemyPrefabs = null;
    [SerializeField] float spawnIntervalTime = 0.5f;
    [SerializeField] float spawnCallTime = 0f;
    [SerializeField]Vector3 spawnCords = new Vector3();
    [SerializeField] float firstRowPos = 0;
    [SerializeField] int maxPerRow = 10;

    [Header("Odds")]
    [SerializeField] int diveEnemyOdds = 0;
    [SerializeField] int shootEnemyOdds = 0;
    [SerializeField] int strongEnemyOdds = 0;

    int[] rowAmount = new int[5];

    int currentEnemy = 0;
    int spawnCount = 0;
    float spawnTimer = 0f;
    float waitTimer = 0f;

    private void Awake()
    {
        current = this;
    }

    private void Update()
    {
        if(spawnCount > 0)
        {
            
            spawnTimer -= Time.deltaTime;
            if(spawnTimer <= 0f)
            {
                GrunderFiender enemy = Instantiate(enemyPrefabs[currentEnemy], spawnCords, Quaternion.identity).GetComponent<GrunderFiender>();

                switch(currentEnemy)
                {
                    case 0:
                        if (rowAmount[0] < maxPerRow)
                        {
                            enemy.verticalstartpos = firstRowPos;
                            rowAmount[0]++;
                        }
                        else
                        {
                            enemy.verticalstartpos = firstRowPos + 1;
                            rowAmount[1]++;
                        }
                        break;
                    case 1:
                        if (rowAmount[2] < maxPerRow)
                        {
                            enemy.verticalstartpos = firstRowPos + 2;
                            rowAmount[2]++;
                        }
                        else
                        {
                            enemy.verticalstartpos = firstRowPos + 3;
                            rowAmount[3]++;
                        }
                        break;
                    case 2:
                        enemy.verticalstartpos = firstRowPos + 4;
                        rowAmount[4]++;
                        break;
                }

                spawnCount--;
                spawnTimer = spawnIntervalTime;
            }
        }
        else
        {
            waitTimer -= Time.deltaTime;
            if(waitTimer <= 0f)
            {
                SpawnEnemySet(10);

                waitTimer = spawnCallTime;
            }
        }
    }

    public void SpawnEnemySet(int enemyAmount)
    {
        currentEnemy = RandomEnemy();

        if(currentEnemy != -1)
        {
            if(currentEnemy != 2)
            {
                spawnCount = Mathf.Clamp(enemyAmount, 0, maxPerRow * 2 - GetEnemyAmount(currentEnemy));
            }
            else
            {
                spawnCount = Mathf.Clamp(enemyAmount, 0, maxPerRow - GetEnemyAmount(currentEnemy));
            }
            spawnTimer = spawnIntervalTime;
        }

    }

    int RandomEnemy()
    {
        int random = Random.Range(0, diveEnemyOdds + shootEnemyOdds + strongEnemyOdds + 1);

        if(random < diveEnemyOdds)
        {
            if(GetEnemyAmount(0) < maxPerRow * 2)
            {
                return 0;
            }
            else if(GetEnemyAmount(1) < maxPerRow * 2)
            {
                return 1;
            }
            else if (GetEnemyAmount(2) < maxPerRow)
            {
                return 2;
            }
        }
        else if(random < diveEnemyOdds + shootEnemyOdds)
        {
            if (GetEnemyAmount(1) < maxPerRow * 2)
            {
                return 1;
            }
            else if (GetEnemyAmount(0) < maxPerRow * 2)
            {
                return 0;
            }
            else if (GetEnemyAmount(2) < maxPerRow)
            {
                return 2;
            }
        }
        else
        {
            if (GetEnemyAmount(2) < maxPerRow)
            {
                return 2;
            }
            else if (GetEnemyAmount(0) < maxPerRow * 2)
            {
                return 0;
            }
            else if (GetEnemyAmount(1) < maxPerRow * 2)
            {
                return 1;
            }
        }


        return -1;
    }

    int GetEnemyAmount(int enemyType)
    {
        switch(enemyType)
        {
            case 0:
                return rowAmount[0] + rowAmount[1];
            case 1:
                return rowAmount[2] + rowAmount[3];
            case 2:
                return rowAmount[4];
        }
        return -1;
    }

    public void EnemyDead(float enemyYStartPosition)
    {
        print(Mathf.FloorToInt(enemyYStartPosition - firstRowPos));
        rowAmount[Mathf.FloorToInt(enemyYStartPosition - firstRowPos)]--;
    }
}

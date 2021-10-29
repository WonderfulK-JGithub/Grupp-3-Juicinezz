using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour //av K-J
{
    public static EnemySpawner current = null;

    [SerializeField] GameObject[] enemyPrefabs = null; //array med prefabs p� v�ra 3 fiender
    [SerializeField] float spawnIntervalTime = 0.5f;//hur l�ng tid det ska vara mellan varje fiendes spawn i ett set
    [SerializeField] float spawnCallTime = 0f;// hur l�ng tid det ska vara mellan olika spawn-sets
    
    [SerializeField] Vector3 spawnCords = new Vector3();//vart fienden ska spawna
    [SerializeField] float firstRowPos = 0; //vilken y h�jd som den l�gsta raden har
    [SerializeField] int maxPerRow = 10; //hur m�nga fiender det f�r vara p� en rad

    [Header("Increase difficulty")]
    [SerializeField] float difficultyDelay = 0f; //hur l�nge i sekunder det �r mellan varje difficult increase
    [SerializeField, Range(0.80f, 0.99f)] float spawnCallRecution = 0f; //hur mycket spawnCallTime ska minska efter en viss tid. Detta ska g�ra att spelet blir stegvis sv�rare
    public float enemyExtraSpeed = 0f;//kommer g�ra att fienden r�r sig och g�r andra saker snabbare
    [SerializeField] float extraSpeedIncrease = 0f;//hur mycket extraspeed enemies ska f� efter (difficultyDelay) sekunder
    [SerializeField] float maxExtraSpeed = 0f;//enemies kan inte f� mer extra speed �n detta

    [Header("Odds")] //odsen f�r att spawna en typ av fiende
    [SerializeField] int diveEnemyOdds = 0;
    [SerializeField] int shootEnemyOdds = 0;
    [SerializeField] int strongEnemyOdds = 0;

    int[] rowAmount = new int[5];//array som h�ller koll p� hur m�nga fiender det finns p� varje rad

    int currentEnemy = 0;//vilken typ av fiende som ska spawnas (0,1 eller 2)
    int spawnCount = 0;//hur m�nga fiender som ska spawnas i nuvarande set
    int spawnDirection = 1;//best�mmer vilket h�ll fienden ska komma fr�n n�r den spawnas
    float spawnTimer = 0f;//h�ller tid
    float waitTimer = 0f;//--||--
    float reductionTimer = 0f; //stegvis sv�rare sak grej thing

    private void Awake()
    {
        current = this;
    }

    private void Update()
    {
        if(ScoreManager.current.gameIsOngoing)//kollar om spelet �r ig�ng
        {
            if (spawnCount > 0)
            {

                spawnTimer -= Time.deltaTime;
                if (spawnTimer <= 0f)
                {
                    GrunderFiender enemy = Instantiate(enemyPrefabs[currentEnemy], new Vector3(spawnCords.x * spawnDirection, spawnCords.y, 0f), Quaternion.identity).GetComponent<GrunderFiender>();//spawnar en fiende
                    enemy.direction = spawnDirection;//g�r att den �ker �t r�tt h�ll

                    switch (currentEnemy)//ger enemyn r�tt rad baserat p� vilken typ den �r
                    {
                        //den kollar alltid om den f�rsta raden �r full. �r det s� hamnar fienden p� den andra raden (g�ller inte den starka fienden som bara har en rad)
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
                if (waitTimer <= 0f)
                {
                    SpawnEnemySet(10);//B�rjar p� ett set som (kanske) spawnar 10 fiender

                    waitTimer = spawnCallTime;
                }
            }

            reductionTimer += Time.deltaTime;
            if(reductionTimer >= difficultyDelay)//spelet blir sv�rare varje (difficultyDelay) sekunder
            {
                spawnCallTime *= spawnCallRecution;
                enemyExtraSpeed += extraSpeedIncrease;
                enemyExtraSpeed = Mathf.Clamp(enemyExtraSpeed, 0f, maxExtraSpeed);

                reductionTimer = 0f;
            }
        }
        
    }

    public void SpawnEnemySet(int enemyAmount)
    {
        currentEnemy = RandomEnemy();
        spawnDirection = Random.Range(0, 2) == 0 ? 1 : -1;//ger en random starth�ll p� set:et

        if(currentEnemy != -1)//om currentEnemy == -1 �r alla rader fulla
        {
            if(currentEnemy != 2)
            {
                spawnCount = Mathf.Clamp(enemyAmount, 0, maxPerRow * 2 - GetEnemyAmount(currentEnemy));
                //g�r att det inte spawnas fler fiender �n som f�r plats p� raderna
                //detta g�r att i vissa set:s spawnas det f�rre �n 10 fiender
            }
            else
            {
                spawnCount = Mathf.Clamp(enemyAmount, 0, maxPerRow / 2 - GetEnemyAmount(currentEnemy));//h�lften s� m�nga startka fiender f�r spawna p� sin rad
                //--||-- fast f�r starka fienden
            }
            if(enemyExtraSpeed < 1)spawnTimer = spawnIntervalTime;
            else spawnTimer = spawnIntervalTime / enemyExtraSpeed;
        }

    }

    int RandomEnemy()
    {
        int random = Random.Range(0, diveEnemyOdds + shootEnemyOdds + strongEnemyOdds + 1);//ett random v�rde som best�mmer vilken fiende som ska spawnas

        //om den slumpvalda fienden inte har plats i sin rad v�ljer den en annan typ av fiende
        if(random < diveEnemyOdds)//dive fiende
        {
            if(GetEnemyAmount(0) < maxPerRow * 2)
            {
                return 0;
            }
            else if(GetEnemyAmount(1) < maxPerRow * 2)
            {
                return 1;
            }
            else if (GetEnemyAmount(2) < maxPerRow * 0.5)
            {
                return 2;
            }
        }
        else if(random < diveEnemyOdds + shootEnemyOdds) //shoot fiende
        {
            if (GetEnemyAmount(1) < maxPerRow * 2)
            {
                return 1;
            }
            else if (GetEnemyAmount(0) < maxPerRow * 2)
            {
                return 0;
            }
            else if (GetEnemyAmount(2) < maxPerRow * 0.5)
            {
                return 2;
            }
        }
        else //stark fiende
        {
            if (GetEnemyAmount(2) < maxPerRow * 0.5)
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


        return -1;//alla rader �r fulla om man kommer hit i koden
    }

    int GetEnemyAmount(int enemyType)//returnar hur m�nga det finns p� raden baserat p� enemy type
    {
        
        switch(enemyType)
        {
            case 0:
                return rowAmount[0] + rowAmount[1];
            case 1:
                return rowAmount[2] + rowAmount[3];
            case 2:
                return rowAmount[4];//stark fiende har bara 1 rad
        }
        return -1;
    }

    public void EnemyDead(float enemyYStartPosition)//tar bort fienden fr�n rowAmount arrayen n�r den har d�tt
    {
        rowAmount[Mathf.FloorToInt(enemyYStartPosition - firstRowPos)]--;
    }
}

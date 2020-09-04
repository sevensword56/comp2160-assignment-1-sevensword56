using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public float enemyDelayMin = 1.0f, enemyDelayMax = 2.0f, timeOfStages = 30.0f;
    public int minAtSpawn = 1, maxAtSpawn = 5;
    public WallSpawner topLeft, topMiddle, topRight, rightTop, rightMiddle, rightBottom
    , bottomLeft, bottomMiddle, bottomRight, leftTop, leftMiddle, leftBottom;

    private float timer = 1.0f;
    private float timeActive = 1.0f;
    private int spawnNumber, totalStages, currentStage = 1;
    private float timeOfNextChange = 1.0f, delayChange = 1.0f, currentSpawnDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {   
        timeActive = 0;
        spawnNumber = minAtSpawn;
        timeOfNextChange = timeOfStages;
        totalStages = maxAtSpawn - minAtSpawn;
        delayChange = (enemyDelayMax - enemyDelayMin) / totalStages;
        currentSpawnDelay = enemyDelayMax;
        timer = enemyDelayMax;
    }

    // Update is called once per frame
    void Update()
    {
        timeActive += Time.deltaTime;
        timer -= Time.deltaTime;

        // Incremental difficulty

        if(timeOfNextChange <= timeActive && currentStage < totalStages)
        {
            if(spawnNumber <= maxAtSpawn)
                spawnNumber ++;
            if(currentSpawnDelay >= enemyDelayMin)
                currentSpawnDelay -= delayChange;
            
            timeOfNextChange += timeOfStages;
            currentStage ++;
        }

        // Activate Spawners

        if(timer <= 0)
        {
            for(int i=0; i < spawnNumber; i++)
            {
                int spawnerSelector = Random.Range(1, 13);

                switch (spawnerSelector)
                {
                    case 1:
                        topLeft.isActive = true;
                        break;
                    case 2:
                        topMiddle.isActive = true;
                        break;
                    case 3:
                        topRight.isActive = true;
                        break;
                    case 4:
                        rightTop.isActive = true;
                        break;
                    case 5:
                        rightMiddle.isActive = true;
                        break;
                    case 6:
                        rightBottom.isActive = true;
                        break;
                    case 7:
                        bottomLeft.isActive = true;
                        break;
                    case 8:
                        bottomMiddle.isActive = true;
                        break;
                    case 9:
                        bottomRight.isActive = true;
                        break;
                    case 10:
                        leftTop.isActive = true;
                        break;
                    case 11:
                        leftMiddle.isActive = true;
                        break;
                    case 12:
                        leftBottom.isActive = true;
                        break;
                }
            }

            timer = currentSpawnDelay;
        }
    }
}

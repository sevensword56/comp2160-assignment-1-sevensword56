using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public float enemyDelay = 5.0f;
    public Transform target1;
    public Transform target2;
    public Transform target3;

    private float timer = 1.0f;
    private Transform targetFinal;
    private bool targetSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = enemyDelay;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(targetSelected == false)
        {
            int targetNumber = Random.Range(1, 4);

            switch (targetNumber)
            {
                case 1:
                    targetFinal = target1;
                    break;
                case 2:
                    targetFinal = target2;
                    break;
                case 3: 
                    targetFinal = target3;
                    break;
            }
            targetSelected = true;
        }

        if(timer <= 0 && targetSelected == true)
        {
            Enemy enemy = Instantiate(enemyPrefab);
            enemy.transform.parent = transform;
            enemy.transform.position = transform.position;
            enemy.target = targetFinal;
            targetSelected = false;
            timer = enemyDelay;
        }
    }
}

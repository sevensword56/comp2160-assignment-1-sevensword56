using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform player;
    public bool isActive = false;
    public Player playerScript;

    private Transform targetFinal;
    private bool targetSelected = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(targetSelected == false && isActive == true)
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

        if(targetSelected == true)
        {
            Enemy enemy = Instantiate(enemyPrefab);
            enemy.transform.parent = transform;
            enemy.transform.position = transform.position;
            enemy.target = targetFinal;
            enemy.player = player;
            enemy.playerScript = playerScript;
            targetSelected = false;
            isActive = false;
        }
    }

}

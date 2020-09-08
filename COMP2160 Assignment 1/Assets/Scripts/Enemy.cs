using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public Transform player;
    public float enemySpeed = 1.0f, minBulletTime = 1.0f, maxBulletTime = 1.0f;
    public BulletEnemy bulletPrefab;
    public Coin coinPrefab;
    public ScoreKeeper scoreKeeper;

    private float randomBulletTime = 1.0f, timeActive = 0.0f;
    private bool hasShot = false;

    // Start is called before the first frame update
    void Start()
    {
        randomBulletTime = Random.Range(minBulletTime, maxBulletTime);
    }

    // Update is called once per frame
    void Update()
    {
        timeActive += Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, target.position, (enemySpeed * Time.deltaTime));

        if(randomBulletTime >= timeActive && hasShot == false && player != null)
        {
            BulletEnemy bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position;
            bullet.playerDirection = player.position;
            hasShot = true;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Coin coin = Instantiate(coinPrefab);
        coin.transform.position = transform.position;
        coin.scoreKeeper = scoreKeeper;
        Destroy(gameObject);
    }
}

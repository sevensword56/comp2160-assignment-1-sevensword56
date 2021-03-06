﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float playerSpeed = 1.0f;
    public Bullet bulletPrefab;
    public float bulletDelay = 1.0f;
    public ScoreKeeper scoreKeeper;

    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject findSingle = GameObject.Find("ScoreKeeper");

        if(findSingle != null)
        {
            scoreKeeper = findSingle.gameObject.GetComponent(typeof(ScoreKeeper)) as ScoreKeeper;
        }
        else
        {
            Debug.LogError("Could not find ScoreKeeper");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Timer update
        timer -= Time.deltaTime;

        // Player Movement
        float movementVertical = (Input.GetAxis("Vertical") * playerSpeed) * Time.deltaTime;
        float movementHorizontal = (Input.GetAxis("Horizontal") * playerSpeed) * Time.deltaTime;

        transform.Translate(movementHorizontal, movementVertical, 0);

        // Player Shooting
        int fireVertical = 0;
        int fireHorizontal = 0;

        if(Input.GetAxis("Vertical Fire") > 0)
        {
            fireVertical = 1;
        }
        else if(Input.GetAxis("Vertical Fire") < 0)
        { 
            fireVertical = -1;
        }

        if(Input.GetAxis("Horizontal Fire") > 0)
        {
            fireHorizontal = 1;
        }
        else if(Input.GetAxis("Horizontal Fire") < 0)
        {
            fireHorizontal = -1;
        }
        if((fireVertical != 0 || fireHorizontal != 0) && timer <= 0)
        {
            timer = bulletDelay;
            Bullet bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position;
            bullet.yMovement = fireVertical;
            bullet.xMovement = fireHorizontal;
        }  
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.GetComponent(typeof(Enemy)) != null)
        {
            Destroy(gameObject);
            scoreKeeper.Reset();
        }
        if(collision.gameObject.GetComponent(typeof(BulletEnemy)) != null)
        {
            Destroy(gameObject);
            scoreKeeper.Reset();
        }
    }
}

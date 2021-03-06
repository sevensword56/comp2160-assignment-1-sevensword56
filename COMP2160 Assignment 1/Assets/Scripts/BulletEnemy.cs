﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public Vector3 playerDirection;
    public float bulletSpeed = 5.0f;
    
    private Vector3 endDirection;

    // Start is called before the first frame update
    void Start()
    {
        endDirection = transform.TransformPoint(transform.InverseTransformPoint(playerDirection)*10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endDirection, (bulletSpeed * Time.deltaTime));

        //if(transform.position == endDirection)
        //    endDirection *= 2;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}

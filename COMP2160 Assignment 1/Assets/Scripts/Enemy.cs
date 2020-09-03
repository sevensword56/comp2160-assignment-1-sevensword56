using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float enemySpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, (enemySpeed * Time.deltaTime));
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}

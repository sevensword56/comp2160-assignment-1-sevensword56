using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float yMovement = 1.0f;
    public float xMovement = 1.0f;
    public float bulletSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movementVertical = (yMovement * bulletSpeed) * Time.deltaTime;
        float movementHorizontal = (xMovement * bulletSpeed) * Time.deltaTime;

        transform.Translate(movementHorizontal, movementVertical, 0);
    }
}

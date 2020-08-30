using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 1.0f;
    public Bullet prefab;
    public float bulletDelay = 1.0f;

    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
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
            fireVertical = 1;
        else if(Input.GetAxis("Vertical Fire") < 0)
            fireVertical = -1;
        
        if(Input.GetAxis("Horizontal Fire") > 0)
            fireHorizontal = 1;
        else if(Input.GetAxis("Horizontal Fire") < 0)
            fireHorizontal = -1;

        if((fireVertical != 0 || fireHorizontal != 0) && timer <= 0)
        {
            timer = bulletDelay;
            Bullet bullet = Instantiate(prefab);
            bullet.transform.position = transform.position;
            bullet.yMovement = fireVertical;
            bullet.xMovement = fireHorizontal;
            bullet.transform.parent = transform;
        }
    }
}

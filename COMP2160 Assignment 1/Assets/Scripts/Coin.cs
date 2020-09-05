using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float delay = 5.0f;
    public ScoreKeeper scoreKeeper;

    private float timeActive = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeActive += Time.deltaTime;

        if(timeActive >= delay)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent(typeof(Player)) != null)
            scoreKeeper.AddScore();
        Destroy(gameObject);
    }
}

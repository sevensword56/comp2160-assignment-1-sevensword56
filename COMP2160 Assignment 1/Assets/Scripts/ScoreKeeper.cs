using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{ 
    public int coinScore = 200;
    public Text scoreText;
    public Text highestScoreText;
    public Canvas canvas;
    public Button buttonPrefab;

    private int score = 0;
    private int highestScore = 0;

    static private ScoreKeeper instance;
    static public ScoreKeeper Instance
    {
        get
        {
            if (instance = null)
            {
                Debug.LogError("There is not a ScoreKeeper in the scene");
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        highestScoreText.text = highestScore.ToString();

        if(score > highestScore)
            highestScore = score;
    }

    void Awake()
    {
        if( instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void Reset()
    {
        score = 0;
        Button button = Instantiate(buttonPrefab);
        button.transform.parent = canvas.transform;
    }

    public void AddScore ()
    {
        score += coinScore;
    }
}

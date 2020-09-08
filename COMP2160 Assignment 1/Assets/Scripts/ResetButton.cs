using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent(typeof(Button)) as Button;
        button.onClick.AddListener(Reset);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Reset()
    {
        SceneManager.LoadScene(0);
        Debug.Log("reset plz");
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText()
    {
        Debug.Log("score is " + score);
        text.text = "Your score is " + score;
    }
}

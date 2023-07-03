using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public static int score = 0;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        switch(other.gameObject.tag)
        {
            case "JumpOne":
                SetScore(score+3);
                break;
            case "JumpTwo":
                SetScore(score+2);
                break;
            case "JumpThree":
                SetScore(score+1);
                break;
            default:
                break;
        }
    }

    void SetScore(int newScore)
    {
        score = newScore;
        SetText();
    }

    void SetText()
    {
        GameOver.score = score;
        text.text = "Score: " + score; 
    }

    public static void ResetScore()
    {
        score = 0;
    }
}

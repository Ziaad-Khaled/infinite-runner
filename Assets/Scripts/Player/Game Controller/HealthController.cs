using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 

public class HealthController : MonoBehaviour
{

    private int healthPoints = 5;
    private int maxHealthPoints = 5;
    public TextMeshProUGUI text;
    ScoreController ScoreController;
    public AudioSource collectSound;
    public AudioSource hitSound;
    public AudioSource refuse;
    bool isInvisible = false;

    // Start is called before the first frame update
    void Start()
    {
        ScoreController = GetComponent<ScoreController>();
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.G))
        {
            SetHealthPoints(healthPoints+1);
        }
        if(Input.GetKeyUp(KeyCode.H))
        {
            SetHealthPoints(healthPoints-1);
        }
        if(Input.GetKeyUp(KeyCode.L))
        {
            isInvisible = !isInvisible;
        }
    }



    private void OnTriggerEnter(Collider other) {
        Renderer  m = other.GetComponent<Renderer>();
        //do not forget to deactivate objects when collision
        switch(other.gameObject.tag)
        {
            case "ObstaclePrefab":
                m.enabled = false;
                break;
            case "ObstacleOne":
                if(!isInvisible)
                {
                    PlayHitSoundEffect();
                    SetHealthPoints(healthPoints - 3);
                    m.enabled = false;
                }
                break;
            case "ObstacleTwo":
                if(!isInvisible)
                {
                    PlayHitSoundEffect();
                    SetHealthPoints(healthPoints - 2);
                    m.enabled = false;
                }
                break;
            case "ObstacleThree":
                if(!isInvisible)
                {
                    PlayHitSoundEffect();
                    SetHealthPoints(healthPoints - 1);
                    m.enabled = false;
                }
                break;
            case "RedOrb":
                bool healthChanged = SetHealthPoints(healthPoints + 1);
                if(healthChanged)
                    m.enabled = false;
                break;
            default:
                break;
        }
    }

    public bool SetHealthPoints(int newPoints)
    {
        if(newPoints > maxHealthPoints)
        {
            refuse.Play();
            return false;
        }
        
        if(newPoints <= 0)
        {
            //death
            Debug.Log("dead");
            GameOver();
            return false;
        }
        if(newPoints > healthPoints)
            PlayCollectSoundEffect();
        healthPoints = newPoints;
        SetText();
        return true;
    }

    public int GetHealthPoints()
    {
        return healthPoints;
    }

    void SetText()
    {
        text.text = "Health: " + healthPoints;
    }

    void PlayCollectSoundEffect()
    {
        collectSound.Play();
    }

    void PlayHitSoundEffect()
    {
        hitSound.Play();
    }

    public void GameOver()
    {
        ScoreController.ResetScore();
        SceneManager.LoadScene(2);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AbilityPointsController : MonoBehaviour
{

    private int abilityPoints = 10;
    private int maxAbilityPoints = 10;

    private bool specialAbilityActivated = false;
    public TextMeshProUGUI text;
    public AudioSource collectSound;
    public AudioSource refuse;
    

    // Start is called before the first frame update
    void Start()
    {
        SetText(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Q))
        {
            ActivateSpecialAbility();
        }
        if(Input.GetKeyUp(KeyCode.J))
        {
            SetAbilityPoints(abilityPoints+1);
        }
        if(Input.GetKeyUp(KeyCode.K))
        {
            SetAbilityPoints(abilityPoints-1);
        }
    }

     public bool SetAbilityPoints(int newPoints)
    {
        
        if(newPoints > maxAbilityPoints)
        {
            refuse.Play();
            return false;
        }
        
        if(newPoints < 0)
        {
            refuse.Play();
            return false;
        }

        if(newPoints > abilityPoints)
            PlaySoundEffect();
        abilityPoints = newPoints;
        SetText();
        return true;
    }

    public int GetAbilityPoints()
    {
        return abilityPoints;
    }

    public void ActivateSpecialAbility()
    {
        if(abilityPoints >= 5)
        {
            abilityPoints -= 5;
            specialAbilityActivated = true;
            //eliminate obstacles
            Generator.ActivateSpecialAbility();
            SetText();
            specialAbilityActivated = false;
        }
        else
        {
            //can't do it 
            return;
        }
    }

    private void OnTriggerEnter(Collider other)  {
        Renderer  m = other.GetComponent<Renderer>();
        //To do: deactivate object
        switch(other.gameObject.tag)
        {
            case "YellowOrb":
                bool abilityChanged = SetAbilityPoints(abilityPoints + 1);
                if(abilityChanged)
                    m.enabled = false;
            break;
            default:
            break;
        }
    }

    private void SetText()
    {
        text.text = "Ability: " + abilityPoints;
    }

    void PlaySoundEffect()
    {
        if(Sound.sound)
        {
            collectSound.Play();
        }
    }


    
}

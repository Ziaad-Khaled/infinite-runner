using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    AbilityPointsController abilityPointsController;

    float x = 0;
    float yForce = 150;
    bool jumpClicked = false;
    bool isJump = false;
    bool isInTheAir = false;
    bool rightButtonClicked = false;
    bool leftButtonClicked = false;

    // Start is called before the first frame update
    void Start()
    {
         abilityPointsController = GetComponent<AbilityPointsController>();
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("android button clicked: " + andriodButtonClicked);
        if(Input.GetKeyUp(KeyCode.Space))
            jumpClicked = true;
        if(!rightButtonClicked && !leftButtonClicked)
            x = Input.GetAxis("Horizontal")*5;
        ProcessJump();
    }

    void FixedUpdate() {
        UpdatePosition();
    }



    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Floor"))
        {
            isInTheAir = false;
        }
    }

    private void OnCollisionExit(Collision other) {
        if(other.gameObject.CompareTag("Floor"))
        {
            isInTheAir = true;
        }
    }

    void UpdatePosition()
    {
        this.transform.position += new Vector3(x,0,0)*  Time.deltaTime;
    }

    public void ProcessJump()
    {
        if(jumpClicked)
        {
            
            if(!isInTheAir)
            {
                AddJumpForce();
            }      
            
        }
        else
        {
            if(isJump)
            {
                Invoke("RemoveJumpForce", 0.05f);
            }
        }
        jumpClicked = false;
    }

    void AddJumpForce()
    {
        bool abilityPointsChanged = abilityPointsController.SetAbilityPoints(abilityPointsController .GetAbilityPoints() - 1);
        if(abilityPointsChanged)
        {
            this.GetComponent<ConstantForce>().force = new Vector3(0,yForce,0);
            isJump = true;
        }   
    }

    void RemoveJumpForce()
    {
        isJump = false;
        this.GetComponent<ConstantForce>().force = new Vector3(0,0,0);
    }

    public void ClickJump()
    {
        jumpClicked = true;
    }

    public void StartMovingRight()
    {
        Debug.Log("Up");
        rightButtonClicked = true;
        x += 4;
    }

    public void StopMovingRight()
    {
        Debug.Log("Down");
        rightButtonClicked = false;
        x = 0;
    }

    public void StartMovingLeft()
    {
        Debug.Log("Up");
        leftButtonClicked = true;
        x += -4;
    }

    public void StopMovingLeft()
    {
        Debug.Log("Down");
        leftButtonClicked = false;
        x = 0;
    }

}

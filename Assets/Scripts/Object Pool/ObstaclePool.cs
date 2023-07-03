using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    Generator generator; 
    public static ObstaclePool SharedInstance; 
    public List<GameObject> pooledObstacleOne; 
    public GameObject obstacleOneToPool;
    public List<GameObject> pooledObstacleTwo; 
    public GameObject obstacleTwoToPool;
    public List<GameObject> pooledObstacleThree; 
    public GameObject obstacleThreeToPool;   
    public int amountToPool = 10;
    



    float  yPosition = 0.04f;
    float [] obstacleOneXPosition = {-2f, 0f, 2f};
    float []  obstacleTwoXPosition = {-1f, 1f};

     void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        generator = GetComponent<Generator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateIntialObstacles()
    {
        GenerateIntialObstacleOne();
        GenerateIntialObstacleTwo();
        GenerateIntialObstacleThree();
    }

    private void GenerateIntialObstacleOne()
    {
        pooledObstacleOne = new List<GameObject>(); 
        GameObject tmp; 
        for(int i = 0; i < amountToPool; i++) 
        { 
            tmp = Instantiate(obstacleOneToPool); 
            tmp.SetActive(false); 
            pooledObstacleOne.Add(tmp); 
        }
    }

    private void GenerateIntialObstacleTwo()
    {
        pooledObstacleTwo = new List<GameObject>(); 
        GameObject tmp; 
        for(int i = 0; i < amountToPool; i++) 
        { 
            tmp = Instantiate(obstacleTwoToPool); 
            tmp.SetActive(false); 
            pooledObstacleTwo.Add(tmp); 
        }
    }

    private void GenerateIntialObstacleThree()
    {
        pooledObstacleThree = new List<GameObject>(); 
        GameObject tmp; 
        for(int i = 0; i < amountToPool; i++) 
        { 
            tmp = Instantiate(obstacleThreeToPool); 
            tmp.SetActive(false); 
            pooledObstacleThree.Add(tmp); 
        }
    }

    

    private GameObject GetObstacleOne() 
    {
        for(int i = 0; i < amountToPool; i++) 
        { 
            if(!pooledObstacleOne[i].activeInHierarchy) 
            {
                generator.addActivatedObject(pooledObstacleOne[i]);
                return pooledObstacleOne[i]; 
            } 
        } 
        return null;
    }

    private GameObject GetObstacleTwo() 
    {
        for(int i = 0; i < amountToPool; i++) 
        { 
            if(!pooledObstacleTwo[i].activeInHierarchy) 
            {
                generator.addActivatedObject(pooledObstacleTwo[i]);
                return pooledObstacleTwo[i]; 
            } 
        } 
        return null;
    }

    private GameObject GetObstacleThree() 
    {
        for(int i = 0; i < amountToPool; i++) 
        { 
            if(!pooledObstacleThree[i].activeInHierarchy) 
            {
                generator.addActivatedObject(pooledObstacleThree[i]);
                return pooledObstacleThree[i]; 
            } 
        } 
        return null;
    }

    public void ActivateObstacleOne(float zPosition)
    {
        int random = Random.Range(0, 3);
        float xPosition = obstacleOneXPosition[random];
        GameObject obstacle = SharedInstance.GetObstacleOne();
        if (obstacle != null) 
        { 
            obstacle.transform.position = new Vector3(xPosition, yPosition, zPosition);
            obstacle.SetActive(true); 
        }
    }

    public void ActivateObstacleTwo(float zPosition)
    {
        int random = Random.Range(0, 2);
        float xPosition = obstacleTwoXPosition[random];
        GameObject obstacle = SharedInstance.GetObstacleTwo();
        if (obstacle != null) 
        { 
            obstacle.transform.position = new Vector3(xPosition, yPosition, zPosition);
            obstacle.SetActive(true); 
        }
    }


    public void ActivateObstacleThree(float zPosition)
    {
        GameObject obstacle = SharedInstance.GetObstacleThree();
        if (obstacle != null) 
        { 
            obstacle.transform.position = new Vector3(0, yPosition, zPosition);
            obstacle.SetActive(true); 
        }
    }

    
}

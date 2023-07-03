using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    ObstaclePool obstaclePool;
    RedOrbPool redOrbPool;
    YellowOrbPool yellowOrbPool;
    public static LinkedList<GameObject>  activatedObjects;
    int spaceBetweenObjects = 5;
    int intialPosition = 10;
    public int objectsToBeAdded = 0;
    float lastZPosition = -2f;
    float firstZPosition = 45f;
    float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        activatedObjects = new LinkedList<GameObject>();
        obstaclePool = GetComponent<ObstaclePool>();
        redOrbPool = GetComponent<RedOrbPool>();
        yellowOrbPool = GetComponent<YellowOrbPool>();
        obstaclePool.GenerateIntialObstacles();
        redOrbPool.GenerateIntialObjects();
        yellowOrbPool.GenerateIntialObjects();
        redOrbPool.SetGenerator();
        yellowOrbPool.SetGenerator();
        ActivateIntialObjects();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 1)
        {
            int zPosition = 7*spaceBetweenObjects + intialPosition;
            ActivateObject(zPosition);
            timer = 0f;
        }
        DeactivateIdleObjects();
    }

    void ActivateIntialObjects()
    {
        int intialNumber = 8;
        float zPosition;
        for(int i = 0; i < intialNumber; i++)
        {
            zPosition = spaceBetweenObjects*i + intialPosition;
            ActivateObject(zPosition);       
        }
    }

    void ActivateObject(float zPosition)
    {
        var RndB = new System.Random();
        var RndA = RndB.Next(0,200000);
        int random = RndA % 6;

        switch (random) {
            case 0:
                obstaclePool.ActivateObstacleOne(zPosition);
                break;
            case 1:
                ActivateOrb(zPosition);
                break;
            case 2:
                obstaclePool.ActivateObstacleTwo(zPosition);
                break;
            case 3:
                ActivateOrb(zPosition);
                break;
            case 4:
                obstaclePool.ActivateObstacleThree(zPosition);
                break;
            case 5:
                ActivateOrb(zPosition);
                break;
            
            default :
                break;
           }
    }
/*
    public void ActivateObstacle(float zPosition)
    {
        var RndB = new System.Random();
        var RndA = RndB.Next(0,200000);
        int random = RndA % 3;
        switch(random)
        {
             case 0:
                obstaclePool.ActivateObstacleOne(zPosition);
                break;
            case 1:
                obstaclePool.ActivateObstacleTwo(zPosition);
                break;
            case 2:
                obstaclePool.ActivateObstacleThree(zPosition);
                break;
            default:
                break;
        }
    }
*/
    public void ActivateOrb(float zPosition)
    {
        for(float xPosition = -2f; xPosition < 3; xPosition +=2)
        {
            var RndB = new System.Random();
            var RndA = RndB.Next(0,200000);
            int random = RndA % 3;
           switch (random) {
            case 0:
                redOrbPool.ActivateObject(zPosition, xPosition);                
                break;
            case 1:
                yellowOrbPool.ActivateObject(zPosition, xPosition);
                break;
            default :
                break;
           }
        }
    }

    public void addActivatedObject(GameObject gameObject)
    {
        activatedObjects.AddLast(gameObject);
    }

    public void DeactivateObject()
    {
        activatedObjects.First.Value.SetActive(false);
        Renderer  m = activatedObjects.First.Value.GetComponent<Renderer>();
        m.enabled = true;
        activatedObjects.RemoveFirst();
    }

    void DeactivateIdleObjects()
    {
        while(!activatedObjects.First.Value.activeInHierarchy)
        {
            DeactivateObject();
        }

        //deactivating moving objects
        Vector3 position = activatedObjects.First.Value.transform.position;
        while(position.z <= lastZPosition)
        {
            DeactivateObject();
            position = activatedObjects.First.Value.transform.position;
        }
    }

    void CheckObjectsPosition()
    {
        bool objectDeactivated = false;
        Vector3 position = activatedObjects.First.Value.transform.position;
        while(position.z <= lastZPosition)
        {
            DeactivateObject();
            objectDeactivated = true;
            position = activatedObjects.First.Value.transform.position;
        }
        int zPosition = 7*spaceBetweenObjects + intialPosition;
        if(objectDeactivated)
        {
            ActivateObject(zPosition);
        }
    }

    public static void ActivateSpecialAbility()
    {
       LinkedListNode<GameObject> node = activatedObjects.First; 
       while(node != null)
        {
            if (node.Value.tag == "ObstaclePrefab")
            {
                node.Value.SetActive(false);
            }
            node  = node.Next;
        }
        
    }

    



    
}

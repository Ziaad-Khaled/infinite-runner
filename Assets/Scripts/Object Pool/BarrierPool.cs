using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierPool : MonoBehaviour
{
    public static BarrierPool SharedInstance; 
    public List<GameObject> pooledObjects; 
    public GameObject objectToPool; 
    public int amountToPool;
    LinkedList<GameObject>  activeBarriers = new LinkedList<GameObject>(); 

    float  yPosition = 0.04f;
    float  xPosition = 1f;
    float lastZPosition = -2f;
    float firstZPosition = 28f; 

    void Awake()
    {
        SharedInstance = this;
    }

    void Start() 
    { 
        GenerateIntialBarriers();        
    }

    void Update() {
        CheckBarriersPosition();
    }

    void GenerateIntialBarriers()
    {
        pooledObjects = new List<GameObject>(); 
        GameObject tmp; 
        for(int i = 0; i < amountToPool; i++) 
        { 
            tmp = Instantiate(objectToPool); 
            tmp.SetActive(false); 
            pooledObjects.Add(tmp); 
        }

        int intialNumber = 10;
        float zPosition;
        for(int i = 0; i < intialNumber; i++)
        {
            zPosition = 3*i + 1;
            ActivateBarriers(zPosition);
        }
    }

    public GameObject GetBarrier() 
    { 
        for(int i = 0; i < amountToPool; i++) 
        { 
            if(!pooledObjects[i].activeInHierarchy) 
            {
                activeBarriers.AddLast(pooledObjects[i]);
                return pooledObjects[i]; 
            } 
        } 
        return null;
    }

    void CheckBarriersPosition()
    {
        Vector3 barrierPosition = activeBarriers.First.Value.transform.position;
        if(barrierPosition.z <= lastZPosition)
        {
            DeactivateFirstTwoBarriers();
            ActivateBarriers(firstZPosition);
        }
    }
    
    void DeactivateFirstTwoBarriers()
    {
        activeBarriers.First.Value.SetActive(false);
        activeBarriers.RemoveFirst();
        activeBarriers.First.Value.SetActive(false);
        activeBarriers.RemoveFirst();
    }

    public void ActivateBarriers(float zPosition)
    {
        GameObject rightBarrier = SharedInstance.GetBarrier();
        if (rightBarrier != null) 
        { 
            rightBarrier.transform.position = new Vector3(xPosition, yPosition, zPosition);
            rightBarrier.SetActive(true); 
        }

        GameObject leftBarrier = SharedInstance.GetBarrier();
        if(leftBarrier != null)
        {
            leftBarrier.transform.position = new Vector3(-xPosition, yPosition, zPosition);
            leftBarrier.SetActive(true); 
        }
    }

}
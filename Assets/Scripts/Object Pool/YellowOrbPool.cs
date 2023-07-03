using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowOrbPool : MonoBehaviour
{
    Generator generator;
    public static YellowOrbPool SharedInstance; 
    public List<GameObject> pooledObjects; 
    public GameObject objectToPool; 
    public int amountToPool;
    LinkedList<GameObject>  activeObjects = new LinkedList<GameObject>();
    float [] xPositionOptions = {-2f, 0f, 2f};
    float  yPosition = 0.5f;    

    void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateObject(float zPosition, float xPosition)
    {
        GameObject yellowOrb = SharedInstance.GetObject();
        if (yellowOrb != null) 
        { 
            yellowOrb.transform.position = new Vector3(xPosition, yPosition, zPosition);
            yellowOrb.SetActive(true); 
        }
    }

    public void GenerateIntialObjects()
    {
        pooledObjects = new List<GameObject>(); 
        GameObject tmp; 
        for(int i = 0; i < amountToPool; i++) 
        { 
            tmp = Instantiate(objectToPool); 
            tmp.SetActive(false); 
            pooledObjects.Add(tmp); 
        }

    }

    public GameObject GetObject() 
    { 
        for(int i = 0; i < amountToPool; i++) 
        {
            if(!pooledObjects[i].activeInHierarchy) 
            {
                generator.addActivatedObject(pooledObjects[i]);
                return pooledObjects[i]; 
            } 
        } 
        return null;
    }

    public void SetGenerator()
    {
        generator = GetComponent<Generator>();
    }

}

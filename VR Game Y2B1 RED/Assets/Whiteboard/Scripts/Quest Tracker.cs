using System.Collections.Generic;
using UnityEngine;

public class QuestTracker : MonoBehaviour
{
    public Growth growth;
    public int questAmount = 1;
    public GameObject spawn;
    public GameObject seedPrefab;
    

    void Update()
    {
        
        if (growth == null)
        {
            GameObject seedInstance = GameObject.FindWithTag("Seed"); 
            if (seedInstance != null)
                growth = seedInstance.GetComponent<Growth>();
                
        }

        // Once growth is known, check for quest completion
        if (growth != null && growth.CarrotsGrown == questAmount)
        {
            
            Vector3 spawnPos = spawn.transform.position;
            Instantiate(seedPrefab, spawnPos, Quaternion.identity);
            growth.condition = true;
            
           // Debug.Log("Reward Granted"+growth);
            
             
        }
    }
}

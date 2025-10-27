using System.Collections.Generic;
using UnityEngine;

public class QuestTracker : MonoBehaviour
{
    public Growth growth;
    public int questAmount = 1;
    public GameObject spawn;
    public GameObject seedPrefab;
    public int totalCarrots = 0;
    public int totalTomatoes = 0;
    public int totalLettuce = 0;
    public bool questOne = false;
    public List<GameObject> Thingie = new List<GameObject>();


    void Update()
    {
        
        if (growth == null)
        {
            GameObject seedInstance = GameObject.FindWithTag("Seed"); 
            if (seedInstance != null)
                growth = seedInstance.GetComponent<Growth>();

            
        }
        

        // destroy seed
        if (growth != null && growth.CarrotsGrown == 1)
        {
            if (!Thingie.Contains(growth.gameObject))
            {
                growth.condition = true;
                if (growth.crop[0] == true) {totalCarrots++;}
                else if (growth.crop[1] == true) { totalTomatoes++;}
                else if (growth.crop[2] == true) { totalLettuce++;}

                    Debug.Log("Carrots grown " + totalCarrots);
                    Debug.Log("Tomatoes grown " + totalTomatoes);
            }

        }
        if(totalCarrots == 4 && questOne == false)
        {
            Vector3 spawnPos = spawn.transform.position;
            Instantiate(seedPrefab, spawnPos, Quaternion.identity);
            
            questOne = true;
        }
        
    }
}

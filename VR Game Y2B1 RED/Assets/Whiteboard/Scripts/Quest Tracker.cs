/*
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public TMP_Text carrotCount;
    


    void Update()
    {
        updateText();
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
                totalCarrots++;
                Debug.Log("Carrots grown " + totalCarrots/2);
            }

        }
        if(totalCarrots/2 == 4 && questOne == false)
        {
            Vector3 spawnPos = spawn.transform.position;
            Instantiate(seedPrefab, spawnPos, Quaternion.identity);
            
            questOne = true;
        }
        
    }

    void updateText()
    {
        carrotCount.text =
        "Quest 1\n" +
        "Get 4 carrots\n" +
        "Progress: " + totalCarrots.ToString() + "/4"
        ;
    }
}
*/

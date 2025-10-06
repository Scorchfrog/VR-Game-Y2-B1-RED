using System.Collections.Generic;
using UnityEditor.UI;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.XR.OpenXR.Input;
using static UnityEngine.ParticleSystem;

public class Ingredient : MonoBehaviour
{
    public List<GameObject> Thingie = new List<GameObject>();
    [SerializeField]
    public bool[] vegetables;
    [SerializeField]
    CollisionTracker collisionTracker;
    bool dirt = false;
    [SerializeField]
    public GameObject spawn;
    [SerializeField]
    public GameObject[] Product;
    [SerializeField]
    public ParticleSystem Particle;
    public DirtCarry carry;

    private void Update()
    {
        if (collisionTracker.GetCollisionCount() == 2)
        {
            StartGrow();
        }
        else return;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Untagged"))
        {
            
            Planted(other.tag, true);
            if (!other.CompareTag("Dirt") && !other.CompareTag("Hoe"))
            {
                if (!Thingie.Contains(other.gameObject))
                {
                    Thingie.Add(other.gameObject);
                    Debug.Log("Skibidi", other);
                }
            }
                
            
        }
        if (other.CompareTag("Dirt") && carry.Attached == false)
        {
            other.gameObject.transform.rotation = spawn.transform.rotation;
            other.gameObject.transform.position = spawn.transform.position;
            Debug.Log("object moves");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Untagged"))
        {
            
            Planted(other.tag, false);
            if (!other.CompareTag("Hoe") && !other.CompareTag("Dirt"))
            {
                if (!Thingie.Contains(other.gameObject))
                {
                    Thingie.Remove(other.gameObject);
                    Debug.Log("Skibidi");
                }
            }
            
        }
    }

    private void Planted(string tag, bool state)
    {
        
        switch (tag)
        {
            case "Carrot":
                vegetables[0] = state;
                break;
            case "Potato":
                vegetables[1] = state;
                break;
            case "Flower":
                vegetables[2] = state;
                break;
            case "Dirt":
                dirt = state;
                break;
            

        }
    }

    private void StartGrow()
    {
        Vector3 spawnPos = (spawn.transform.position);
        for(int i = 0; i < vegetables.Length; i++)
        {
            if (vegetables[i] == true && dirt == true || dirt == true && vegetables[i] == true)
            {
                Instantiate(Particle, spawnPos, Quaternion.identity);
                Instantiate(Product[i], spawnPos, Quaternion.identity);
                Reset();
            }
        }
        
        
    }

    private void Reset() 
    {
        dirt = false;
        for(int i = 0;  i < vegetables.Length; i++)
        {
            vegetables[i] = false;
        }

        collisionTracker.collidingObjects.Clear();
        for (int i = 0; i < Thingie.Count; i++)
        {
            Destroy(Thingie[i]);
        }
        Thingie.Clear();
        Debug.Log("ingredient count" + Thingie.Count);


    }



}

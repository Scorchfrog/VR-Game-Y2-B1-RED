using UnityEngine;
using System.Collections.Generic;

public class CollisionTracker : MonoBehaviour
{
    public GameObject keepThisOne;
    public List<GameObject> collidingObjects = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            if (other.CompareTag("HoedDirt"))
            {
                keepThisOne = other.gameObject;
                if (!collidingObjects.Contains(other.gameObject))
                {
                    collidingObjects.Add(keepThisOne);
                }
            }
            if (!collidingObjects.Contains(other.gameObject))
            {
                collidingObjects.Add(other.gameObject);
            }
        }
        

        Debug.Log("Currently colliding with: " + collidingObjects.Count);
    }

    private void OnTriggerExit(Collider other)
    {
        if (collidingObjects.Contains(other.gameObject))
        {
            collidingObjects.Remove(other.gameObject);
        }

        Debug.Log("Currently colliding with: " + collidingObjects.Count);
    }

   

    public int GetCollisionCount()
    {
        return collidingObjects.Count;
    }
}
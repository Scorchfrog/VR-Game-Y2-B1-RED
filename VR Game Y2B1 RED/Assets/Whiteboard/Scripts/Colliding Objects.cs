using UnityEngine;
using System.Collections.Generic;

public class CollisionTracker : MonoBehaviour
{
    public List<GameObject> collidingObjects = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (!collidingObjects.Contains(other.gameObject))
        {
            collidingObjects.Add(other.gameObject);
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
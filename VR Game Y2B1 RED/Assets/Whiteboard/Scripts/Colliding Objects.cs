using UnityEngine;
using System.Collections.Generic;

public class CollisionTracker : MonoBehaviour
{
    public List<GameObject> collidingObjects = new List<GameObject>();

    private void OnCollisionEnter(Collision collision)
    {
        if (!collidingObjects.Contains(collision.gameObject))
        {
            collidingObjects.Add(collision.gameObject);
        }

        Debug.Log("Currently colliding with: " + collidingObjects.Count);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collidingObjects.Contains(collision.gameObject))
        {
            collidingObjects.Remove(collision.gameObject);
        }

        Debug.Log("Currently colliding with: " + collidingObjects.Count);
    }

    public int GetCollisionCount()
    {
        return collidingObjects.Count;
    }
}
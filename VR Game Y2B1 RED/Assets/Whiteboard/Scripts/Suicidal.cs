using UnityEngine;

public class Suicidal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 2)
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class KinematicsTest : MonoBehaviour
{
    Rigidbody rb;
    public GameObject spawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
        
            rb = other.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            Debug.Log("Is now not kinematic" + other.gameObject.name);
        
        
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        collision.gameObject.transform.SetParent(spawn.gameObject.transform, true);

    }
}

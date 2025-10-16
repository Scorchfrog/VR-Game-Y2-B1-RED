using UnityEngine;

public class DestroyWithseed : MonoBehaviour
{
    public Growth growth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(growth.condition == true)
        {
            Destroy(this.gameObject);
        }
    }
}

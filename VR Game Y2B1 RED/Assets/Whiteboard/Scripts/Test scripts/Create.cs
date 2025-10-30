using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    public int stock = 10;
    [SerializeField]
    private GameObject Item;
    [SerializeField]
    private GameObject SpawnPos;
    public List<GameObject> ListItem = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("LettuceSeed") && !ListItem.Contains(other.gameObject))
        {
            ListItem.Add(other.gameObject);
            
            if (stock != 0)
            {
                StartCoroutine(RestockTime());
            }
        }
        
    }

    private System.Collections.IEnumerator RestockTime()
    {
        Vector3 spawnPos = SpawnPos.transform.position;
        yield return new WaitForSeconds(2);
        Instantiate(Item, spawnPos, Quaternion.identity);
        stock--;
    }
}

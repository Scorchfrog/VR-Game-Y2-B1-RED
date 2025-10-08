using UnityEngine;

public class Growth : MonoBehaviour
{
    public float lifetime = 5f;
    [SerializeField]
    public GameObject carrot;
    [SerializeField]
    public GameObject spawn;
    public int CarrotsGrown = 0;
    public bool condition = false;
    public float growthProgress;
    public float growthTime;
    public float speedMultiplier;

    private void Start()
    {
        Debug.Log("Object created! Timer started.");
        
        StartCoroutine(LifetimeTimer());
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Speewer"))
        {
            speedMultiplier = 3f;
            Destroy(collision.gameObject);
            Debug.Log("Sped Up " + speedMultiplier);
        }
    }

    private System.Collections.IEnumerator LifetimeTimer()
    {
        while (growthProgress < growthTime)
        {
            // Apply speed multiplier
            growthProgress += Time.deltaTime * speedMultiplier;

            // Optional: update a UI bar here
            yield return null;
        }
        CarrotsGrown++;
        Debug.Log("carrots grown" + CarrotsGrown);
        Vector3 spawnPos = (spawn.transform.position);
        Instantiate(carrot, spawnPos, Quaternion.identity);
        
    }

    public void Update()
    {
        if(condition == true)
        {
            Destroy(gameObject);
        }
    }
}
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public GameObject prefab;
    private Vector3 spawnPosition;
    private Quaternion spawnRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    private void Awake()
    {
        spawnPosition = transform.position;
        spawnRotation = transform.rotation;

    }
    private void OnCollisionExit(Collision collision)
    {
        Instantiate(prefab, spawnPosition, spawnRotation);
    }
}

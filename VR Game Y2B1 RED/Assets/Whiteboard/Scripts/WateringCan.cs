using UnityEngine;

public class WateringCan : MonoBehaviour
{
    public ParticleSystem waterEffect;
    public bool isWatering = false;
    [SerializeField] private float tiltThreshold = 90f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if (waterEffect == null)
            return;

        float angle = Vector3.Angle(transform.up, Vector3.up);

        // Check if the watering state should change
        if (angle > tiltThreshold && !isWatering)
        {
            isWatering = true;
            if (!waterEffect.isPlaying)
                waterEffect.Play();
            Debug.Log("Started watering");
        }
        else if (angle <= tiltThreshold && isWatering)
        {
            isWatering = false;
            if (waterEffect.isPlaying)
                waterEffect.Stop();
            Debug.Log("Stopped watering");
        }
    }
}

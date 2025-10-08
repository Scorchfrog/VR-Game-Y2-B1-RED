using UnityEngine;

public class Test : MonoBehaviour
{
    public Timer timer = new();
    [SerializeField]
    public string tag;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer.Update(Time.deltaTime);
    }

    public void FinishedTest()
    {
        timer.Start();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag(tag))
        FinishedTest();
    }
}

using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Timer
{
    public UnityEvent onComplete;
    private float currentTime;
    private bool isRunning;

    public void Start(float time = 0)
    {
        currentTime = time;
        isRunning = true;

    }

    public void Update(float deltaTime)
    {
        if (!isRunning)
        {
            return;
        }

        currentTime += deltaTime;

        if (currentTime >= 5)
        {
            isRunning = false;
            onComplete?.Invoke();
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Suspicion_manager : MonoBehaviour
{
    public Image suspicionBar;
    public float suspicionAmount = 0f;

    public Image addictionBar;
    public float addictionAmount = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GetSuspicion(20);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoseSuspicion(5);
        }
    }

    public void GetSuspicion(int sus)
    {
        suspicionAmount += sus;
        suspicionBar.fillAmount = suspicionAmount / 100f;
    }

    public void LoseSuspicion(int sus)
    {
        suspicionAmount -= suspicionAmount;
        suspicionAmount = Mathf.Clamp(suspicionAmount, 0, 100);

        suspicionBar.fillAmount = suspicionAmount / 100f;
    }

    public void GetAddiction(int addic)
    {
        addictionAmount += addic;
        addictionBar.fillAmount = addictionAmount / 100f;
    }

    public void LoseAddiction(int addic)
    {
        addictionAmount -= addictionAmount;
        addictionAmount = Mathf.Clamp(addictionAmount, 0, 100);

        addictionBar.fillAmount = addictionAmount / 100f;
    }
}

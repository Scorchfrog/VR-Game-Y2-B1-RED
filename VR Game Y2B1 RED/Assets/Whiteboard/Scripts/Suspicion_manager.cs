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
    public Orders orders;
    public float sus;
    public float addic;

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        sus = orders.sus;
        addic = orders.addic;
        
    }

    public void GetSuspicion(float sus)
    {
        suspicionAmount += sus;
        suspicionBar.fillAmount = suspicionAmount / 100f;
    }

    public void LoseSuspicion(float sus)
    {
        Debug.Log("sus" + suspicionAmount);
        suspicionAmount -= sus;
        suspicionAmount = Mathf.Clamp(suspicionAmount, 0, 100);

        suspicionBar.fillAmount = suspicionAmount / 100f;
    }

    public void GetAddiction(float addic)
    {
        addictionAmount += addic;
        addictionBar.fillAmount = addictionAmount / 100f;
    }

    public void LoseAddiction(float addic)
    {
        addictionAmount -= addictionAmount;
        addictionAmount = Mathf.Clamp(addictionAmount, 0, 100);

        addictionBar.fillAmount = addictionAmount / 100f;
    }
}

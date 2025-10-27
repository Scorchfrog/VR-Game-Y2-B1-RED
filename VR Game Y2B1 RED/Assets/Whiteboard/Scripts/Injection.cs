using System;
using UnityEngine;

public class Injection : MonoBehaviour
{
    public GameObject drugged;
    public bool dose1 = false;
    public bool dose2 = false;
    public bool dose3 = false;
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
        if (other.CompareTag("GrownCarrot"))
            Debug.Log("drugged");
        {
            drugged = other.gameObject;
            if (drugged != null)
            {

                if (dose1 == true) { drugged.GetComponent<Drugged>().drug1 = true; Debug.Log("drugged"); }
                else if (dose2 == true) { drugged.GetComponent<Drugged>().drug2 = true; }
                else if (dose3 == true) { drugged.GetComponent<Drugged>().drug3 = true; }
            }
        }
    }
}

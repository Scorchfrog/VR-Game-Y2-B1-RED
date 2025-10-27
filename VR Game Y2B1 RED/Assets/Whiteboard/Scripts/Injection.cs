using System;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class Injection : MonoBehaviour
{
    private GameObject drugged;
    public bool dose1 = false;
    public bool dose2 = false;
    public bool dose3 = false;
    private bool pressed = false;
    public InputActionReference customButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        customButton.action.started += Drop;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Drop(InputAction.CallbackContext context)
    {
        pressed = !pressed;
        Debug.Log("boolean is "+ pressed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GrownCarrot"))
            Debug.Log("drugged");
        {
            drugged = other.gameObject;
            if (drugged != null)
            {

                if (dose1 == true && pressed == true) { drugged.GetComponent<Drugged>().drug1 = true; Debug.Log("drugged"); }
                else if (dose2 == true && pressed == true) { drugged.GetComponent<Drugged>().drug2 = true; }
                else if (dose3 == true && pressed == true) { drugged.GetComponent<Drugged>().drug3 = true; }
            }
        }
    }
}

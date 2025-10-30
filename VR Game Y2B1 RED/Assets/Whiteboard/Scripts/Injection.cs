using System;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class Injection : MonoBehaviour
{
    
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
        if (other.CompareTag("GrownCarrot")|| other.CompareTag("Tomato") || other.CompareTag("Lettuce"))
            Debug.Log("drugged");
        {
   
                if (dose1 == true) { other.gameObject.AddComponent<Drugged>().drug1 = true; Debug.Log("drugged"); return; }
                else if (dose2 == true) { other.gameObject.AddComponent<Drugged>().drug2 = true; return; }
                else if (dose3 == true) { other.gameObject.AddComponent<Drugged>().drug3 = true; }
            
        }
    }
}

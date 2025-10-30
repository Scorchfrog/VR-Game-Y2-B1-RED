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
    public bool alreadyDrugged1 = false;
    public bool alreadyDrugged2 = false;
    public bool alreadyDrugged3 = false;
    private bool pressed = false;
    public int durability = 0;
    public InputActionReference customButton;
    public GameObject injection;
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
            
        {
                injection = other.gameObject;
                if (dose1 == true && injection.GetComponent<Drugged>().drugged == false /*&& pressed == true*/) 
                { 
                injection.GetComponent<Drugged>().drug1 = true; 
                injection.GetComponent<Drugged>().amDrugged(); 
                Debug.Log("drugged");
                pressed = false;
                durability--;
                }
                else if (dose2 == true && injection.GetComponent<Drugged>().drugged == false/*&& pressed == true*/)
                { 
                injection.GetComponent<Drugged>().drug2 = true;
                injection.GetComponent<Drugged>().amDrugged();
                Debug.Log("drugged");
                pressed = false;
                durability--;
                }
                else if (dose3 == true && injection.GetComponent<Drugged>().drugged == false/*&& pressed == true*/)
                { 
                injection.GetComponent<Drugged>().drug3 = true;
                injection.GetComponent<Drugged>().amDrugged();
                Debug.Log("drugged");
                pressed = false;
                durability--;
                }
                if(durability == 0) {Destroy(this.gameObject);}
        }
    }
}

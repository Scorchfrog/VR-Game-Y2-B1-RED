using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Orphan : MonoBehaviour
{
    Rigidbody rb;
    private XRGrabInteractable grabInteractable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnEnable()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    

    private void OnRelease(SelectExitEventArgs args)
    {
        rb.transform.parent = null;
    }
}

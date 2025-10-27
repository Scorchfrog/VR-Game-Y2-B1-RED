using UnityEngine;
using UnityEngine.Events;

public class VegetableBehaviour : MonoBehaviour
{
    [SerializeField] private UnityEvent _ProductSold; //

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //vegetable dissappearing when they get sold
    private void OnMouseDown()
    {
        _ProductSold.Invoke();
        Destroy(gameObject);
    }
}

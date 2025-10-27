using UnityEngine;

public class SellingSystem : MonoBehaviour
{
    //money
    [SerializeField] private int Dollar = 0; //amount of money the player has
    [SerializeField] private int VegPrice = 25; //price of the vegetables

    //the suspicion
    private float SusBar = 0f; //amount of suspicion the player gained
    [SerializeField] private float SusAdd = 10.0f; //amount of suspicion gained (base value)

    //the addiction
    private float AddictBar = 0f; //amount of addiction the player gained
    [SerializeField] private float AddictAdd = 10.0f; //amount of of addiction gained (base value)



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //reaction for selling (outdated)
    public void ReactToClick()
    {
        SellVegetable();
    }

    //selling vegetables system
    private void SellVegetable()
    {
        Debug.Log("Vegetable Sold");

        Dollar += VegPrice;
        Debug.Log($"You have {Dollar}$!");

        SusBar += SusAdd;
        Debug.Log($"SusBar Increased: {SusBar} SUS!");

        AddictBar += AddictAdd;
        Debug.Log($"AddictBar Increased: {AddictBar} ADDICTION!");
    }

}

using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Create : MonoBehaviour
{
    public int stock = 10;
    [SerializeField]
    private GameObject Item;
    [SerializeField]
    private GameObject SpawnPos;
    public List<GameObject> ListItem = new List<GameObject>();
    [SerializeField] private string targetTag = "LettuceSeed";
    public TMP_Text questText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateQuestText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag) && !ListItem.Contains(other.gameObject))
        {
            ListItem.Add(other.gameObject);
            
            if (stock != 0)
            {
                StartCoroutine(RestockTime());
            }
        }
        
    }

    void UpdateQuestText()
    {
        questText.text =
            $"<b>Remaining:</b>\n" +
            $"<b>{stock}</b>\n";

    }

    private System.Collections.IEnumerator RestockTime()
    {
        Vector3 spawnPos = SpawnPos.transform.position;
        yield return new WaitForSeconds(2);
        Instantiate(Item, spawnPos, Quaternion.identity);
        stock--;
        UpdateQuestText();
    }
}

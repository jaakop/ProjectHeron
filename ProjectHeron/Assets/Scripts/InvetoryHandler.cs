using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvetoryHandler : MonoBehaviour {

    [SerializeField]
    private GameObject[] inventorySlots;

    public int numberOfInventorySlots;

    public int itemsInInventory;

	void Start () {
        itemsInInventory = 0;
        numberOfInventorySlots = inventorySlots.Length;
        Debug.Log(numberOfInventorySlots);
	}
	
	void Update () {
        Debug.Log(itemsInInventory);
	}

    public void AddItem(GameObject item, int itemPrefab)
    {
        if (itemsInInventory == inventorySlots.Length)
        {
            Debug.Log("This inventory is full");
        }
        else
        {
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                if (inventorySlots[i].GetComponent<inventorySlotHnadler>().isUsed == false)
                {
                    inventorySlots[i].GetComponent<inventorySlotHnadler>().AddItemToSlot(item, itemPrefab);
                    itemsInInventory++;
                    Destroy(item);
                    break;
                }

            }
        }
    }
}

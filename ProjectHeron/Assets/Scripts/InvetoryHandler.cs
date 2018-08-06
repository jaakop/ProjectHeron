using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvetoryHandler : MonoBehaviour {

    [SerializeField]
    private GameObject[] inventorySlots;

	void Start () {
    
	}
	
	void Update () {
		
	}

    public void AddItem(GameObject item)
    {
        for(int i = 0; i < inventorySlots.Length; i++)
        {
            if(inventorySlots[i].GetComponent<inventorySlotHnadler>().isUsed == false)
            {
                inventorySlots[i].GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
                inventorySlots[i].GetComponent<Image>().color = item.GetComponent<SpriteRenderer>().color;
                inventorySlots[i].GetComponent<inventorySlotHnadler>().isUsed = true;
                break;
            }

        }
    }
}

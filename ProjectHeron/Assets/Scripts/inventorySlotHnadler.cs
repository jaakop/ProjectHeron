﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class inventorySlotHnadler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public bool isUsed;

    [SerializeField]
    private Sprite defaultImage;

    [SerializeField]
    private Color defaultColor;

    [SerializeField]
    int slotPrefab;

    bool cursorInsideSlot;

    GameObject player;
    playerScript playerScript;


	// Use this for initialization
	void Start () {
        isUsed = false;
        cursorInsideSlot = false;
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<playerScript>();
	}
	
	// Update is called once per frame
	void Update () { 

        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 cursorPosition3D = new Vector3(cursorPosition.x, cursorPosition.y, 0);
        if (Input.GetMouseButtonDown(0) && cursorInsideSlot)
        {
            if (isUsed)
            {
                gameObject.GetComponent<Image>().sprite = defaultImage;
                gameObject.GetComponent<Image>().color = defaultColor;
                GameObject itemCatalogue = GameObject.Find("GameHandler");
                GameObject itemPrefab = itemCatalogue.GetComponent<ItemCatalog>().itemPrefabs[slotPrefab]; ;
                GameObject newGameObject = Instantiate(itemPrefab, cursorPosition3D, Quaternion.identity);
                newGameObject.GetComponent<ItemHandler>().isHold = true;
                isUsed = false;
            }
            else
            {
                if (playerScript.isHolding)
                {
                    AddItemToSlot(playerScript.item, playerScript.itemIndex);
                    isUsed = true;
                    Destroy(playerScript.item);
                }
            }
        }
		
	}

    public void AddItemToSlot(GameObject item, int prefab)
    {
        slotPrefab = prefab;
        gameObject.GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
        Color itemColor = item.GetComponent<SpriteRenderer>().color;
        itemColor.a = 1;
        gameObject.GetComponent<Image>().color = itemColor;
        isUsed = true;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        cursorInsideSlot = true;
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        cursorInsideSlot = false;
    }
}

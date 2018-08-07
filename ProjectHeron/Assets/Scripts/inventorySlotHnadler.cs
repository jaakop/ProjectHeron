using System.Collections;
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

	// Use this for initialization
	void Start () {
        isUsed = false;
        cursorInsideSlot = false;
	}
	
	// Update is called once per frame
	void Update () { 

        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 cursorPosition3D = new Vector3(cursorPosition.x, cursorPosition.y, 0);
        if (Input.GetMouseButtonDown(0) && cursorInsideSlot)
        {
            gameObject.GetComponent<Image>().sprite = defaultImage;
            gameObject.GetComponent<Image>().color = defaultColor;
            GameObject itemCatalogue = GameObject.Find("GameHandler");
            GameObject itemPrefab = itemCatalogue.GetComponent<ItemCatalog>().itemPrefabs[slotPrefab]; ;
            GameObject newGameObject = Instantiate(itemPrefab, cursorPosition3D, Quaternion.identity);
            newGameObject.GetComponent<ItemHandler>().isHold = true;
            isUsed = false;
        }
		
	}

    public void AddItemToSlot(GameObject item, int prefab)
    {
        slotPrefab = prefab;
        gameObject.GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
        gameObject.GetComponent<Image>().color = item.GetComponent<SpriteRenderer>().color;
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

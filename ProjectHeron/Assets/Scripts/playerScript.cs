using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour {

    public bool oxygenAttacehd;
    private Image oxygenBar;
    private GameObject oxygenBarObject;
    [SerializeField]
    float oxygenRegen;
    [SerializeField]
    float oxygenLost;
    [SerializeField]
    private GameObject playerHighLight;

    private Transform highLight;

    public bool highLighted;

    private float oxygenBarLenght;

    public bool cursorInsidePlayer;

    public bool isHolding;

    public GameObject item;
    public int itemIndex;

	void Start () {
        oxygenBarObject = GameObject.Find("oxygenBar");
        if(oxygenBarObject)
        oxygenBar = oxygenBarObject.GetComponent<Image>();
        oxygenBarLenght = oxygenBar.rectTransform.sizeDelta.y;
        highLighted = false;
        cursorInsidePlayer = false;
        isHolding = false;
    }
	
	void Update () {
        if (highLighted)
        {
            playerHighLight.SetActive(true);
        }
        else
        {
            playerHighLight.SetActive(false);
        }
        if (oxygenBar)
        {
            if (oxygenAttacehd)
            {
                if(oxygenBar.rectTransform.sizeDelta.y < oxygenBarLenght)
                    oxygenBar.rectTransform.sizeDelta = new Vector2(oxygenBar.rectTransform.sizeDelta.x, oxygenBar.rectTransform.sizeDelta.y + oxygenRegen);
            }
            else
            {
                if (oxygenBar.rectTransform.sizeDelta.y > 0)
                    oxygenBar.rectTransform.sizeDelta = new Vector2(oxygenBar.rectTransform.sizeDelta.x, oxygenBar.rectTransform.sizeDelta.y - oxygenLost);
            }
        }

        if (item)
        {
            if (cursorInsidePlayer)
            {
                item.GetComponent<ItemHandler>().Snap(transform.position, true, gameObject);
                highLighted = true;
            }
            else
            {
                item.GetComponent<ItemHandler>().Snap(transform.position, false, gameObject);
                highLighted = false;
            }
        }

	}   

    private void OnMouseEnter()
    {
        cursorInsidePlayer = true;
    }
    private void OnMouseExit()
    {
        cursorInsidePlayer = false;
    }

}

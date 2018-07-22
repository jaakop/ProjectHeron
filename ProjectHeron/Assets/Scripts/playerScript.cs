﻿using System.Collections;
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

    private float oxygenBarLenght;

	void Start () {
        oxygenBarObject = GameObject.Find("oxygenBar");
        if(oxygenBarObject)
        oxygenBar = oxygenBarObject.GetComponent<Image>();
        oxygenBarLenght = oxygenBar.rectTransform.sizeDelta.y;

    }
	
	void Update () {
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
	}
}

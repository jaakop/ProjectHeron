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
	void Start () {
        oxygenBarObject = GameObject.Find("oxygenBar");
        if(oxygenBarObject)
        oxygenBar = oxygenBarObject.GetComponent<Image>();
	}
	
	void Update () {
        if (oxygenBar)
        {
            if (oxygenAttacehd)
            {
                if(oxygenBar.rectTransform.sizeDelta.x < 200)
                    oxygenBar.rectTransform.sizeDelta = new Vector2(oxygenBar.rectTransform.sizeDelta.x + oxygenRegen, oxygenBar.rectTransform.sizeDelta.y);
            }
            else
            {
                if (oxygenBar.rectTransform.sizeDelta.x > 0)
                    oxygenBar.rectTransform.sizeDelta = new Vector2(oxygenBar.rectTransform.sizeDelta.x - oxygenLost, oxygenBar.rectTransform.sizeDelta.y);
            }
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour {

    public GameObject player;
    private LineRenderer lr;
    [SerializeField]
    private float lineDistance;
    playerScript playerScript;
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
        lr = gameObject.GetComponent<LineRenderer>();
        playerScript = player.GetComponent<playerScript>();
	}
	
	void Update () {
        if (player) {
            float distance = Vector2.Distance(player.transform.position, transform.position);
            if (distance < lineDistance)
            {
                lr.SetPosition(0, new Vector3(transform.position.x, transform.position.y));
                lr.SetPosition(1, new Vector3(player.transform.position.x, player.transform.position.y));
                playerScript.oxygenAttacehd = true;
            }
            else
            {
                lr.SetPosition(0, new Vector3(transform.position.x, transform.position.y));
                lr.SetPosition(1, new Vector3(transform.position.x, transform.position.y));
                playerScript.oxygenAttacehd = false;
            }
        }
	}
}

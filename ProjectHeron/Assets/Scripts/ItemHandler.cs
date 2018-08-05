using UnityEngine;

public class ItemHandler : MonoBehaviour {

    public bool isHold;
    private bool insideObject;
    [SerializeField]
    private float moveSpeed;

    GameObject player;
    playerScript playerScript;
	// Use this for initialization
	void Start () {
        isHold = false;
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<playerScript>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (isHold)
        {
            Vector2 vector = Vector2.Lerp(transform.position, cursorPosition, moveSpeed * Time.deltaTime);
            transform.position = vector;
        }
        if (Input.GetMouseButtonDown(0) && insideObject)
        {
            if (!isHold)
                isHold = true;
            else
                isHold = false;
        }
	}
    private void OnMouseEnter()
    {
        insideObject = true;
    }

    private void OnMouseExit()
    {
        insideObject = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            playerScript.highLighted = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            playerScript.highLighted = false;
    }

}

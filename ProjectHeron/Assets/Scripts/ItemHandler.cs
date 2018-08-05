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
            if (cursorPosition.x - transform.position.x > 0.025 || cursorPosition.x - transform.position.x < -0.025)
            {
                if (cursorPosition.y - transform.position.y > 0.025 || cursorPosition.y - transform.position.y < -0.025)
                {
                    Vector2 vector = new Vector2(cursorPosition.x - transform.position.x, cursorPosition.y - transform.position.y);
                    vector.Normalize();
                    transform.position = new Vector2(transform.position.x + vector.x * moveSpeed, transform.position.y + vector.y * moveSpeed);
                }
            }
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

using UnityEngine;

public class ItemHandler : MonoBehaviour {

    public bool isHold;

    private bool insideObject;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float placementSpeed;

    GameObject player;

    playerScript playerScript;

    private bool snapping;

    Vector2 targetPosition;

    void Start () {
        isHold = false;
        snapping = false;
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<playerScript>();
	}

	void Update () {
        if (isHold)
        {
            playerScript.item = gameObject;
            GetComponent<Collider2D>().enabled = false;
            if(snapping)
            {
                Vector2 vector = Vector2.Lerp(transform.position, targetPosition, placementSpeed * Time.deltaTime);
                transform.position = vector;
                Color tmp = GetComponent<SpriteRenderer>().color;
                tmp.a = 0.5f;
                GetComponent<SpriteRenderer>().color = tmp;

            }
            else
            {
                Vector2 vector = Vector2.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                transform.position = vector;
                Color tmp = GetComponent<SpriteRenderer>().color;
                tmp.a = 1f;
                GetComponent<SpriteRenderer>().color = tmp;
            }
        }
        else
        {
            GetComponent<Collider2D>().enabled = true;
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

    public void Snap(Vector2 snappingPosition, bool isSnapping)
    {
        snapping = isSnapping;
        if(isSnapping)
            targetPosition = snappingPosition;
        else
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}

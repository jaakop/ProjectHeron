using UnityEngine;

public class ItemHandler : MonoBehaviour {

    public bool isHold;

    private bool insideObject;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float placementSpeed;

    [SerializeField]
    int itemPrefab;

    private bool snapping;

    Vector2 targetPosition;

    GameObject snappingGameObject;

    GameObject player;
    playerScript playerScript;

    void Start () {
        snapping = false;
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<playerScript>();
	}

	void Update () {
        playerScript.isHolding = isHold;
        if (isHold)
        {
            playerScript.item = gameObject;
            playerScript.itemIndex = itemPrefab;
            if(snapping)
            {
                GetComponent<Collider2D>().enabled = false;
                Vector2 vector = Vector2.Lerp(transform.position, targetPosition, placementSpeed * Time.deltaTime);
                transform.position = vector;
                Color tmp = GetComponent<SpriteRenderer>().color;
                tmp.a = 0.5f;
                GetComponent<SpriteRenderer>().color = tmp;
                if (Input.GetMouseButtonDown(0))
                {
                    
                    snappingGameObject.GetComponent<InvetoryHandler>().AddItem(gameObject,  itemPrefab);
                    Destroy(gameObject);
                }
            }
            else
            {
                GetComponent<Collider2D>().enabled = true;
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
            {
                isHold = true;
            }
            else
            {
                isHold = false;
            }
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

    public void Snap(Vector2 snappingPosition, bool isSnapping, GameObject snappingObject)
    {
        snapping = isSnapping;
        snappingGameObject = snappingObject;
        if(isSnapping)
            targetPosition = snappingPosition;
        else
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}

using UnityEngine;

[DisallowMultipleComponent]
public class Wallmovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float moveRange = 10f;
    [SerializeField] private float startDelay = 30f;

    private Vector3 initialPosition;
    private bool isMovingRight = true;
    private bool canMove = false;
    private Renderer wallRenderer;
    private Collider wallCollider;
    private float startTime;

    void Start()
    {
        initialPosition = transform.position;

     
        if (!TryGetComponent<Renderer>(out wallRenderer))
        {
            Debug.LogError("Renderer component not found!", this);
            enabled = false;
            return;
        }

       
        if (!TryGetComponent<Collider>(out wallCollider))
        {
            Debug.LogError("Collider component not found!", this);
            enabled = false;
            return;
        }

        
        wallRenderer.enabled = false;
        wallCollider.enabled = false;

        startTime = Time.time;
    }

    void Update()
    {
       
        if (!canMove && Time.time - startTime >= startDelay)
        {
            canMove = true;
            wallRenderer.enabled = true;
            wallCollider.enabled = true;
        }

        if (canMove) MoveWall();
    }

    void MoveWall()
    {
        float movement = moveSpeed * Time.deltaTime * (isMovingRight ? 1 : -1);
        float newX = transform.position.x + movement;

      
        if (isMovingRight && newX > initialPosition.x + moveRange)
        {
            newX = initialPosition.x + moveRange;
            isMovingRight = false;
        }
        else if (!isMovingRight && newX < initialPosition.x - moveRange)
        {
            newX = initialPosition.x - moveRange;
            isMovingRight = true;
        }

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
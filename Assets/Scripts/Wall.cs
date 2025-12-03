using UnityEngine;

public class Wall : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float moveRange = 10f;

    private Vector3 startPosition;
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
    
        if (movingRight)
        {
            
            if (transform.position.x < startPosition.x + moveRange)
            {
                transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);
            }
            else
            {
                movingRight = false;
            }
        }
        else
        {
            
            if (transform.position.x > startPosition.x - moveRange)
            {
                transform.Translate(-moveSpeed * Time.deltaTime, 0f, 0f);
            }
            else
            {
                movingRight = true;
            }
        }
    }
}
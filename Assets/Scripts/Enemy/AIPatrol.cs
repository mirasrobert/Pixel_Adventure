using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    const string LEFT = "left";
    const string RIGHT = "right";

    [SerializeField] float moveSpeed = 1f;
    [SerializeField] Transform castPos;
    [SerializeField] float baseCaseDistance;

    Rigidbody2D rb2d;

    private string facingDirection;

    private Vector3 baseScale;

    private void Start()
    {
        baseScale = transform.localScale;
        facingDirection = RIGHT;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        float moveX = moveSpeed;
        if(facingDirection == LEFT)
        {
            moveX = -moveSpeed;
        }

        // Movement speed of the gameobject
        rb2d.velocity = new Vector2(moveX, rb2d.velocity.y);

        if(isHittingWall() || isNearEdge())
        {
            if (facingDirection == LEFT)
            {
                ChangeFaceDirection(RIGHT);
            }
            else if(facingDirection == RIGHT)
            {
                ChangeFaceDirection(LEFT);
            }
        }
       
    }

    void ChangeFaceDirection(string newDirection)
    {
        Vector3 newScale = baseScale;

        if(newDirection == LEFT) {
            newScale.x = -baseScale.x;
        } else
        {   // Right
            newScale.x = baseScale.x;
        }

        transform.localScale = newScale;
        facingDirection = newDirection;
    }
    
    bool isHittingWall()
    {
        bool val = false;
        float castDist = baseCaseDistance;

        // Define the cast distance for left and right
        if (facingDirection == LEFT)
        {
            castDist = -baseCaseDistance;
        }
        else
        { 
            castDist = baseCaseDistance;
        }

        // Determine the target destination based on cast distance
        Vector3 targetPos = castPos.position;
        targetPos.x += castDist;

        // Draw a Line
        Debug.DrawLine(castPos.position, targetPos, Color.blue);


        // Check if cast hit a foreground
        if (Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Foreground")))
        { 
            val = true;
        }
        else
        {
            val = false;
        }

        return val;
    }

    bool isNearEdge()
    {
        bool val = true;
        float castDist = baseCaseDistance;

        // Determine the target destination based on cast distance
        Vector3 targetPos = castPos.position;
        targetPos.y -= castDist;

        // Draw a Line
        Debug.DrawLine(castPos.position, targetPos, Color.green);


        // Check if cast does not hit cast hit a foreground
        if (Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Foreground")))
        {
            val = false;
        }
        else
        {
            val = true;
        }

        return val;
    }

}

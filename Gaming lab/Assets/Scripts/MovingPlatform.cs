using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingPlatform : MonoBehaviour
{
    // Platform will move continuously between these 2 points
    public Transform pointA;
    public Transform pointB;

    public float speed;
    private bool atB = true;

    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = pointA.position;
    }

    void Update()
    {
        // The platform should always start its journey from Point B to Point A
        // Once it reaches Point A, it begins moving back toward Point B
        if (atB == true)
        {
            targetPosition = pointA.position;
        }
        else
        {
            targetPosition = pointB.position;
        }

        // Move towards target position on the X-axis only
        Vector3 newPosition = transform.position;

        newPosition.x = Mathf.MoveTowards(
            transform.position.x,
            targetPosition.x,
            speed * Time.deltaTime
        );

        transform.position = newPosition;

        // Switch direction when arriving at target
        if (Mathf.Abs(transform.position.x - targetPosition.x) < 0.1f)
        {
            atB = !atB;
        }
    }

    // Make the player a child of the platform when landing on it
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }
    }

    // Unparent the player when jumping off the platform
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}
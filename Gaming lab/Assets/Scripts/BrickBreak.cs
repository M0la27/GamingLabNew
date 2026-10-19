using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBreak : MonoBehaviour
{
    // Used to change the sprite
    private SpriteRenderer sr;

    // The sprite to change into
    public Sprite explodedBlock;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Called when something hits the BrickBlock
    void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the collision hit the bottom of the block
        if (other.gameObject.tag == "Player" &&
            other.GetContact(0).point.y < transform.position.y)
        {
            // Change the block sprite
            sr.sprite = explodedBlock;

            // Wait a fraction of a second and then destroy the BrickBlock
            Destroy(gameObject, 0.2f);
        }
    }
}
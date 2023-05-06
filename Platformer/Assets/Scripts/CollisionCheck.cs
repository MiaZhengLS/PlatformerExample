using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public bool IsOnGround
    {
        get;
        private set;
    }
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsOnGround = collision.gameObject.CompareTag("Ground");
        if(IsOnGround)
        {
            spriteRenderer.color = Color.green;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = false;
            spriteRenderer.color = Color.red;
        }
    }
}

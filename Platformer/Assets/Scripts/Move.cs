using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float maxAccer;
    private Rigidbody2D rb2d;
    private PlayerController controller;
    private float desiredMove; 
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
    }

    void Update()
    {
        desiredMove = controller.inputController.GetMoveInput();
    }

    void FixedUpdate()
    {
        // Time.fixedDeltaTime
        switch(controller.moveMode)
        {
            case MoveMode.AddForce:
                // f = m * a
                // a = v / t
                var force = rb2d.mass * (desiredMove * maxSpeed - rb2d.velocity.x) / Time.fixedDeltaTime;
                rb2d.AddForce(force * Vector2.right);
                break;
            case MoveMode.Impulse:
                // p = m * v
                var impulse = rb2d.mass * (desiredMove * maxSpeed - rb2d.velocity.x);
                rb2d.AddForce(impulse * Vector2.right, ForceMode2D.Impulse);
                break;
            case MoveMode.SetVelocity:
                var velocity = rb2d.velocity;
                velocity.x = Mathf.MoveTowards(velocity.x, desiredMove * maxSpeed, maxAccer);
                rb2d.velocity = velocity;
                break;
        }
    }
}

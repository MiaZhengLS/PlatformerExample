using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private float jumpTime;
    [SerializeField]
    private CollisionCheck collisionCheck;
    [SerializeField]
    private float fallFasterGravityFactor;
    [SerializeField]
    private float EarlyExitGravityFactor;
    [SerializeField]
    private int maxJumpCount;
    private Rigidbody2D rb2d;
    private PlayerController controller;
    private bool desireJump;
    private float jumpGravity;
    private float gravityScaleFactor;
    private float initJumpSpeed;
    private int curJumpCount;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
        // h = -1/2 * g * t^2
        jumpGravity = -2 * jumpHeight / Mathf.Pow(jumpTime, 2);
        gravityScaleFactor = jumpGravity / Physics2D.gravity.y;
        rb2d.gravityScale = gravityScaleFactor;
        // v = -g * t
        initJumpSpeed = -jumpGravity * jumpTime;
    }

    void Update()
    {
        desireJump |= controller.inputController.GetJumpInput();
    }

    void FixedUpdate()
    {
        if (rb2d.velocity.y < 0 && !collisionCheck.IsOnGround)
        {
            rb2d.gravityScale = gravityScaleFactor * fallFasterGravityFactor;
            controller.animationController.ChangeState(PlayerState.Fall);
        }
        else if(rb2d.velocity.y >0 && !controller.inputController.GetJumpHoldingInput())
        {
            rb2d.gravityScale = gravityScaleFactor * EarlyExitGravityFactor;
        }
        else
        {
            rb2d.gravityScale = gravityScaleFactor;
            if(collisionCheck.IsOnGround)
            {
                if(controller.inputController.GetMoveInput() != 0)
                {
                    controller.animationController.ChangeState(PlayerState.Run);
                }
                else
                {
                    controller.animationController.ChangeState(PlayerState.Idle);
                }
                curJumpCount = 0;
            }
        }
        if ( desireJump && curJumpCount < maxJumpCount)
        {
            switch (controller.moveMode)
            {
                case MoveMode.AddForce:
                case MoveMode.Impulse:
                    // p = m*v
                    rb2d.AddForce(rb2d.mass * Vector2.up * initJumpSpeed, ForceMode2D.Impulse);
                    desireJump = false;
                    break;
                case MoveMode.SetVelocity:
                    var velocity = rb2d.velocity;
                    velocity.y = initJumpSpeed;
                    rb2d.velocity = velocity;
                    desireJump = false;
                    break;
            }
            curJumpCount++;
            controller.animationController.ChangeState(PlayerState.Jump);
        }
       
    }
}

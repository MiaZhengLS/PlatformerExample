using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]
    private float initJumpSpeed;
    private Rigidbody2D rb2d;
    private PlayerController controller;
    private bool desireJump;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
    }

    void Update()
    {
        desireJump |= controller.inputController.GetJumpInput();
    }

    void FixedUpdate()
    {
        if( desireJump )
        {
            switch (controller.moveMode)
            {
                case MoveMode.AddForce:
                case MoveMode.Impulse:
                    rb2d.AddForce(rb2d.mass * Vector2.up * initJumpSpeed, ForceMode2D.Impulse);
                    desireJump = false;
                    break;
                case MoveMode.SetVelocity:
                    break;
            }
        }
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveMode
{
    AddForce,
    Impulse,
    SetVelocity
}

public enum PlayerState
{
    Idle,
    Run,
    Jump,
    Fall
}

public class PlayerController : MonoBehaviour
{
    public MoveMode moveMode;
    public InputController inputController;
    public PlayerAnimationController animationController;
}

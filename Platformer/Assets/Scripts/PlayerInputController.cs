using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Create Input Controller/Player Input Controller", fileName = "PlayerInputController")]
public class PlayerInputController : InputController
{
    public override bool GetJumpInput()
    {
        return Input.GetButtonDown("Jump");
    }

    public override float GetMoveInput()
    {
        return Input.GetAxis("Horizontal");
    }
}

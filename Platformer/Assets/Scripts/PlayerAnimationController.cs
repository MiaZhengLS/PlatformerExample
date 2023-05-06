using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private int animationKeyHash;

    void Start()
    {
        animator = GetComponent<Animator>();
        animationKeyHash = Animator.StringToHash("state");
    }

    public void ChangeState(PlayerState playerState)
    {
        if(animator.GetInteger(animationKeyHash) != (int)playerState)
        {
            animator.SetInteger(animationKeyHash, (int)playerState);
        }
    }
}

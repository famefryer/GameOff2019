using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator animator;
    public bool isAnimationRunning;

    public void PlayAttack()
    {
        animator.SetTrigger("NormalAttack");
        isAnimationRunning = true;
    }

    public void AttackingAnimationComplete()
    {
        isAnimationRunning = false;
    }
}

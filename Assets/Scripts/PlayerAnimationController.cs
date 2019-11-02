using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator animator;

    public void PlayAttack()
    {
        animator.SetTrigger("NormalAttack");
    }

}

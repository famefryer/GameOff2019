﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator animator;
    public bool isAttackingAnimationRunning;
    public bool isSpecialAttackingAnimationRunning;

    public void PlayAttack()
    {
        animator.SetTrigger("NormalAttack");
        isAttackingAnimationRunning = true;
    }

    public void PlaySpecialAttack()
    {
        animator.SetTrigger("SpecialAttack");
        isSpecialAttackingAnimationRunning = true;
        GameManager.Instance.multiplySpeed = 2;
        StartCoroutine(WaitForSpecialAttackEnd(5f));
    }

    private IEnumerator WaitForSpecialAttackEnd(float time)
    {
        yield return new WaitForSeconds(time);
        isSpecialAttackingAnimationRunning = false;
        animator.SetTrigger("EndSpecialAttack");
        GameManager.Instance.multiplySpeed = 1;
    }
    public void AttackingAnimationComplete()
    {
        isAttackingAnimationRunning = false;
    }
}

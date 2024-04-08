using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimation : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void AnimWalk()
    {
        animator.SetBool("isWalking", true);
    }

    public void AnimIdle()
    {
        animator.SetBool("isWalking", false);
    }
    public void AnimAttack()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) return;
        animator.SetTrigger("isAttacking");
    }
    public void AnimDeath()
    {
        animator.SetTrigger("isDeath");
    }
    public void AnimHurt()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Hurt")) return;
        animator.SetTrigger("isHurting");
    }
}
